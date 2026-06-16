using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using OrganizadorCampeonato.Dominio.Entidades;
using OrganizadorCampeonato.Dominio.Enum;
using OrganizadorCampeonato.Dominio.Excepciones;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.TorneoEquipos.Comandos.MarcarEliminadoTorneoEquipo
{
    public class CasoDeUsoMarcarEliminadoTorneoEquipo : IRequestHandler<ComandoMarcarEliminadoTorneoEquipo>
    {
        private readonly IRepositorioTorneoEquipo repositorioTorneoEquipo;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoMarcarEliminadoTorneoEquipo(IRepositorioTorneoEquipo repositorioTorneoEquipo, IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorioTorneoEquipo = repositorioTorneoEquipo;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoMarcarEliminadoTorneoEquipo request)
        {
            var torneoEquipoExistente = await repositorioTorneoEquipo.ObtenerPorId(request.Id);
            if (torneoEquipoExistente is null)
                throw new ExcepcionDeValidacion("No se encontró la inscripción del equipo");

            if (torneoEquipoExistente.Estado == EstadoInscripcion.Campeon)
                throw new ExcepcionReglaDeNegocio("No se puede eliminar a un equipo campeón");

            if (torneoEquipoExistente.Estado == EstadoInscripcion.Eliminado)
                throw new ExcepcionReglaDeNegocio("El equipo ya está eliminado");

            var torneoEquipoActualizado = new TorneoEquipo(
                request.Id,
                request.TorneoId,
                request.EquipoId,
                request.Posicion
            )
            {
                Estado = EstadoInscripcion.Eliminado,
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
