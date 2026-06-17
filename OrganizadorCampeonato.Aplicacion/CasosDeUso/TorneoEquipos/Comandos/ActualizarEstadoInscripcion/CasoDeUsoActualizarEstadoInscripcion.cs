using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using OrganizadorCampeonato.Dominio.Entidades;
using OrganizadorCampeonato.Dominio.Excepciones;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.TorneoEquipos.Comandos.ActualizarEstadoInscripcion
{
    public class CasoDeUsoActualizarEstadoInscripcion : IRequestHandler<ComandoActualizarEstadoInscripcion>
    {
        private readonly IRepositorioTorneoEquipo repositorioTorneoEquipo;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoActualizarEstadoInscripcion(IRepositorioTorneoEquipo repositorioTorneoEquipo, IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorioTorneoEquipo = repositorioTorneoEquipo;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoActualizarEstadoInscripcion request)
        {
            var torneoEquipoExistente = await repositorioTorneoEquipo.ObtenerPorTorneoYEquipo(request.TorneoId, request.EquipoId);
            if (torneoEquipoExistente is null)
                throw new ExcepcionDeValidacion("No se encontró la inscripción del equipo en el torneo");

            if (torneoEquipoExistente.Estado == request.Estado)
                throw new ExcepcionReglaDeNegocio($"El equipo ya tiene el estado {request.Estado}");

            var torneoEquipoActualizado = new TorneoEquipo(
                torneoEquipoExistente.Id,
                request.TorneoId,
                request.EquipoId,
                request.Posicion ?? torneoEquipoExistente.Posicion
            )
            {
                Estado = request.Estado,
                FechaInscripcion = torneoEquipoExistente.FechaInscripcion
            };

            try
            {
                await repositorioTorneoEquipo.Actualizar(torneoEquipoActualizado);
                await unidadDeTrabajo.Persistir();
            }
            catch (Exception)
            {
                await unidadDeTrabajo.Reversar();
                throw;
            }
        }
    }
}
