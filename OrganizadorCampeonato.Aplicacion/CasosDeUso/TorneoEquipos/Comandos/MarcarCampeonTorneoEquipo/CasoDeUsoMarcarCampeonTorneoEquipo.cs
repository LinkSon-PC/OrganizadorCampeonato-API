using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using OrganizadorCampeonato.Dominio.Entidades;
using OrganizadorCampeonato.Dominio.Enum;
using OrganizadorCampeonato.Dominio.Excepciones;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.TorneoEquipos.Comandos.MarcarCampeonTorneoEquipo
{
    public class CasoDeUsoMarcarCampeonTorneoEquipo : IRequestHandler<ComandoMarcarCampeonTorneoEquipo>
    {
        private readonly IRepositorioTorneoEquipo repositorioTorneoEquipo;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoMarcarCampeonTorneoEquipo(IRepositorioTorneoEquipo repositorioTorneoEquipo, IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorioTorneoEquipo = repositorioTorneoEquipo;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoMarcarCampeonTorneoEquipo request)
        {
            var torneoEquipoExistente = await repositorioTorneoEquipo.ObtenerPorId(request.Id);
            if (torneoEquipoExistente is null)
                throw new ExcepcionDeValidacion("No se encontró la inscripción del equipo");

            if (torneoEquipoExistente.Estado == EstadoInscripcion.Eliminado)
                throw new ExcepcionReglaDeNegocio("No se puede nombrar campeón a un equipo eliminado");

            if (torneoEquipoExistente.Estado == EstadoInscripcion.Campeon)
                throw new ExcepcionReglaDeNegocio("El equipo ya es campeón");

            var torneoEquipoActualizado = new TorneoEquipo(
                request.Id,
                request.TorneoId,
                request.EquipoId,
                request.Posicion
            )
            {
                Estado = EstadoInscripcion.Campeon,
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
