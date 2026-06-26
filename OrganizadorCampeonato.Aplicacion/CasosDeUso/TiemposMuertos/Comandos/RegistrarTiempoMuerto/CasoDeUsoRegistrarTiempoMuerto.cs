using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using OrganizadorCampeonato.Dominio.Entidades;
using OrganizadorCampeonato.Dominio.Excepciones;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.TiemposMuertos.Comandos.RegistrarTiempoMuerto
{
    public class CasoDeUsoRegistrarTiempoMuerto : IRequestHandler<ComandoRegistrarTiempoMuerto, Guid>
    {
        private readonly IRepositorioTiempoMuerto repositorio;
        private readonly IRepositorioPartido repositorioPartido;
        private readonly IRepositorioEquipo repositorioEquipo;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoRegistrarTiempoMuerto(
            IRepositorioTiempoMuerto repositorio,
            IRepositorioPartido repositorioPartido,
            IRepositorioEquipo repositorioEquipo,
            IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorio = repositorio;
            this.repositorioPartido = repositorioPartido;
            this.repositorioEquipo = repositorioEquipo;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task<Guid> Handle(ComandoRegistrarTiempoMuerto request)
        {
            var partido = await repositorioPartido.ObtenerPorId(request.PartidoId);
            if (partido is null)
                throw new ExcepcionDeValidacion("No se encontro el partido");

            var equipo = await repositorioEquipo.ObtenerPorId(request.EquipoId);
            if (equipo is null)
                throw new ExcepcionDeValidacion("No se encontro el equipo");

            // Regla FIBA: Validar límites de timeouts
            var tiemposMuertosExistentes = await repositorio.ObtenerTodos();
            var timeoutsEquipo = await tiemposMuertosExistentes
                .Where(tm => tm.PartidoId == request.PartidoId && tm.EquipoId == request.EquipoId)
                .ToListAsync();

            var timeoutsEnMitad = timeoutsEquipo
                .Count(tm => tm.EsPrimeraMitad == request.EsPrimeraMitad);

            // Regla FIBA: 2 timeouts en 1ra mitad, 3 en 2da mitad, 1 por OT
            int maxTimeouts;
            if (request.Periodo == Dominio.Enum.TipoPeriodo.Prorroga || request.Periodo == Dominio.Enum.TipoPeriodo.Prorroga2)
                maxTimeouts = 1;
            else if (request.EsPrimeraMitad)
                maxTimeouts = 2;
            else
                maxTimeouts = 3;

            if (timeoutsEnMitad >= maxTimeouts)
                throw new ExcepcionReglaDeNegocio($"El equipo ya ha usado todos sus timeouts disponibles en esta mitad ({maxTimeouts} máximo).");

            var tiempoMuerto = new TiempoMuerto(
                Guid.CreateVersion7(),
                request.PartidoId,
                request.EquipoId,
                request.Periodo,
                request.Minuto,
                request.NumeroTimeout,
                request.EsPrimeraMitad);

            try
            {
                var respuesta = await repositorio.Agregar(tiempoMuerto);
                await unidadDeTrabajo.Persistir();
                return respuesta.Id;
            }
            catch (Exception)
            {
                await unidadDeTrabajo.Reversar();
                throw;
            }
        }
    }
}
