using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using OrganizadorCampeonato.Dominio.Entidades;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.TorneoEquipos.Comandos.AsignarGrupoEquipo
{
    public class CasoDeUsoAsignarGrupoEquipo : IRequestHandler<ComandoAsignarGrupoEquipo>
    {
        private readonly IRepositorioTorneoEquipo repositorio;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoAsignarGrupoEquipo(
            IRepositorioTorneoEquipo repositorio,
            IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorio = repositorio;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoAsignarGrupoEquipo request)
        {
            var torneoEquipo = await repositorio.ObtenerPorId(request.Id);
            if (torneoEquipo is null)
                throw new ExcepcionDeValidacion("No se encontro la inscripcion del equipo");

            var torneoEquipoActualizado = new TorneoEquipo(
                request.Id,
                torneoEquipo.TorneoId,
                torneoEquipo.EquipoId,
                torneoEquipo.Posicion,
                request.Grupo,
                request.PosicionGrupo
            )
            {
                Estado = torneoEquipo.Estado,
                FechaInscripcion = torneoEquipo.FechaInscripcion
            };

            try
            {
                await repositorio.Actualizar(torneoEquipoActualizado);
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
