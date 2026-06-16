using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using OrganizadorCampeonato.Dominio.Entidades;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.TorneoEquipos.Comandos.ActualizarPosicionTorneoEquipo
{
    public class CasoDeUsoActualizarPosicionTorneoEquipo : IRequestHandler<ComandoActualizarPosicionTorneoEquipo>
    {
        private readonly IRepositorioTorneoEquipo repositorioTorneoEquipo;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoActualizarPosicionTorneoEquipo(IRepositorioTorneoEquipo repositorioTorneoEquipo, IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorioTorneoEquipo = repositorioTorneoEquipo;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoActualizarPosicionTorneoEquipo request)
        {
            var torneoEquipoExistente = await repositorioTorneoEquipo.ObtenerPorId(request.Id);
            if (torneoEquipoExistente is null)
                throw new ExcepcionDeValidacion("No se encontró la inscripción del equipo");

            var torneoEquipoActualizado = new TorneoEquipo(
                request.Id,
                request.TorneoId,
                request.EquipoId,
                request.Posicion
            )
            {
                Estado = torneoEquipoExistente.Estado,
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
