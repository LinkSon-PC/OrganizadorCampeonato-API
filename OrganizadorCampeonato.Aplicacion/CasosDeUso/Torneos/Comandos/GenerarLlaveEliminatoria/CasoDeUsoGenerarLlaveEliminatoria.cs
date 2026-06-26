using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using OrganizadorCampeonato.Dominio.Entidades;
using OrganizadorCampeonato.Dominio.Enum;
using OrganizadorCampeonato.Dominio.Excepciones;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Torneos.Comandos.GenerarLlaveEliminatoria
{
    public class CasoDeUsoGenerarLlaveEliminatoria : IRequestHandler<ComandoGenerarLlaveEliminatoria>
    {
        private readonly IRepositorioTorneo repositorioTorneo;
        private readonly IRepositorioTorneoEquipo repositorioTorneoEquipo;
        private readonly IRepositorioPartido repositorioPartido;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoGenerarLlaveEliminatoria(
            IRepositorioTorneo repositorioTorneo,
            IRepositorioTorneoEquipo repositorioTorneoEquipo,
            IRepositorioPartido repositorioPartido,
            IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorioTorneo = repositorioTorneo;
            this.repositorioTorneoEquipo = repositorioTorneoEquipo;
            this.repositorioPartido = repositorioPartido;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoGenerarLlaveEliminatoria request)
        {
            var torneo = await repositorioTorneo.ObtenerPorId(request.TorneoId);
            if (torneo is null)
                throw new ExcepcionDeValidacion("No se encontro el torneo");

            var torneoEquipos = await repositorioTorneoEquipo.ObtenerTodos();
            var equiposClasificados = await torneoEquipos
                .Where(te => te.TorneoId == request.TorneoId && te.PosicionGrupo.HasValue)
                .OrderBy(te => te.PosicionGrupo)
                .ToListAsync();

            if (!equiposClasificados.Any())
                throw new ExcepcionReglaDeNegocio("No hay equipos clasificados para la fase eliminatoria");

            var numEquipos = equiposClasificados.Count;
            var numRondas = (int)Math.Ceiling(Math.Log2(numEquipos));

            if (numEquipos < 2)
                throw new ExcepcionReglaDeNegocio("Se necesitan al menos 2 equipos para generar la llave eliminatoria");

            var fechaActual = request.FechaInicio;
            var partidosPorRonda = new Dictionary<FasePartido, List<Partido>>();

            for (int ronda = numRondas; ronda >= 1; ronda--)
            {
                var fase = ObtenerFase(ronda, numRondas);
                var numPartidos = (int)Math.Pow(2, ronda - 1);
                var partidosDeEstaRonda = new List<Partido>();

                for (int i = 0; i < numPartidos; i++)
                {
                    Guid? partidoOrigenLocalId = null;
                    Guid? partidoOrigenVisitanteId = null;

                    if (ronda < numRondas)
                    {
                        var faseSiguiente = ObtenerFase(ronda + 1, numRondas);
                        var partidosFaseSiguiente = partidosPorRonda[faseSiguiente];
                        var partidoSiguienteIndex = i / 2;

                        if (partidoSiguienteIndex < partidosFaseSiguiente.Count)
                        {
                            var partidoSiguiente = partidosFaseSiguiente[partidoSiguienteIndex];
                            if (i % 2 == 0)
                                partidoOrigenLocalId = partidoSiguiente.Id;
                            else
                                partidoOrigenVisitanteId = partidoSiguiente.Id;
                        }
                    }

                    var partido = new Partido(
                        Guid.CreateVersion7(),
                        fechaActual,
                        request.Lugar,
                        request.TorneoId,
                        fase,
                        1,
                        numeroRondaKO: ronda
                    );

                    partidosDeEstaRonda.Add(partido);
                    await repositorioPartido.Agregar(partido);
                }

                partidosPorRonda[fase] = partidosDeEstaRonda;
                fechaActual = fechaActual.AddDays(1);
            }

            try
            {
                await unidadDeTrabajo.Persistir();
            }
            catch (Exception)
            {
                await unidadDeTrabajo.Reversar();
                throw;
            }
        }

        private FasePartido ObtenerFase(int ronda, int totalRondas)
        {
            var rondaDesdeFinal = totalRondas - ronda + 1;

            return rondaDesdeFinal switch
            {
                1 => FasePartido.Final,
                2 => FasePartido.Semifinal,
                3 => FasePartido.Cuartos,
                4 => FasePartido.Octavos,
                _ => FasePartido.Octavos
            };
        }
    }
}
