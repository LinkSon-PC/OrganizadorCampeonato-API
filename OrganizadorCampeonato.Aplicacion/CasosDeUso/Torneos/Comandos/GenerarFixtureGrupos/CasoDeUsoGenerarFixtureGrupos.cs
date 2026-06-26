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

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Torneos.Comandos.GenerarFixtureGrupos
{
    public class CasoDeUsoGenerarFixtureGrupos : IRequestHandler<ComandoGenerarFixtureGrupos>
    {
        private readonly IRepositorioTorneo repositorioTorneo;
        private readonly IRepositorioTorneoEquipo repositorioTorneoEquipo;
        private readonly IRepositorioPartido repositorioPartido;
        private readonly IRepositorioPartidoEquipo repositorioPartidoEquipo;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoGenerarFixtureGrupos(
            IRepositorioTorneo repositorioTorneo,
            IRepositorioTorneoEquipo repositorioTorneoEquipo,
            IRepositorioPartido repositorioPartido,
            IRepositorioPartidoEquipo repositorioPartidoEquipo,
            IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorioTorneo = repositorioTorneo;
            this.repositorioTorneoEquipo = repositorioTorneoEquipo;
            this.repositorioPartido = repositorioPartido;
            this.repositorioPartidoEquipo = repositorioPartidoEquipo;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoGenerarFixtureGrupos request)
        {
            var torneo = await repositorioTorneo.ObtenerPorId(request.TorneoId);
            if (torneo is null)
                throw new ExcepcionDeValidacion("No se encontro el torneo");

            if (torneo.Formato != FormatoTorneo.GruposMasEliminatoria)
                throw new ExcepcionReglaDeNegocio("El formato del torneo no es GruposMasEliminatoria");

            var torneoEquipos = await repositorioTorneoEquipo.ObtenerTodos();
            var equiposInscritos = await torneoEquipos
                .Where(te => te.TorneoId == request.TorneoId && te.Grupo != null)
                .ToListAsync();

            if (!equiposInscritos.Any())
                throw new ExcepcionReglaDeNegocio("No hay equipos inscritos con grupo asignado");

            var grupos = equiposInscritos
                .GroupBy(te => te.Grupo)
                .OrderBy(g => g.Key)
                .ToList();

            var fechaActual = request.FechaInicio;
            var partidosCreados = new List<Partido>();

            foreach (var grupo in grupos)
            {
                var equiposDelGrupo = grupo.OrderBy(te => te.PosicionGrupo).ToList();
                var numEquipos = equiposDelGrupo.Count;

                if (numEquipos < 2)
                    continue;

                var numJornadas = numEquipos % 2 == 0 ? numEquipos - 1 : numEquipos;
                var partidosPorJornada = numEquipos / 2;

                for (int jornada = 1; jornada <= numJornadas; jornada++)
                {
                    var equiposRotados = RotarEquipos(equiposDelGrupo, jornada - 1);

                    for (int i = 0; i < partidosPorJornada; i++)
                    {
                        var equipoLocal = equiposRotados[i];
                        var equipoVisitante = equiposRotados[numEquipos - 1 - i];

                        var partido = new Partido(
                            Guid.CreateVersion7(),
                            fechaActual,
                            request.Lugar,
                            request.TorneoId,
                            FasePartido.Grupos,
                            jornada,
                            grupo.Key
                        );

                        partidosCreados.Add(partido);

                        var partidoEquipoLocal = new PartidoEquipo(
                            Guid.CreateVersion7(),
                            partido.Id,
                            equipoLocal.EquipoId,
                            true
                        );

                        var partidoEquipoVisitante = new PartidoEquipo(
                            Guid.CreateVersion7(),
                            partido.Id,
                            equipoVisitante.EquipoId,
                            false
                        );

                        await repositorioPartido.Agregar(partido);
                        await repositorioPartidoEquipo.Agregar(partidoEquipoLocal);
                        await repositorioPartidoEquipo.Agregar(partidoEquipoVisitante);
                    }

                    fechaActual = fechaActual.AddDays(1);
                }
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

        private List<TorneoEquipo> RotarEquipos(List<TorneoEquipo> equipos, int rotaciones)
        {
            if (equipos.Count <= 1)
                return equipos;

            var resultado = new List<TorneoEquipo>(equipos);
            var primerEquipo = resultado[0];
            resultado.RemoveAt(0);

            for (int i = 0; i < rotaciones; i++)
            {
                var ultimo = resultado[resultado.Count - 1];
                resultado.RemoveAt(resultado.Count - 1);
                resultado.Insert(0, ultimo);
            }

            resultado.Insert(0, primerEquipo);
            return resultado;
        }
    }
}
