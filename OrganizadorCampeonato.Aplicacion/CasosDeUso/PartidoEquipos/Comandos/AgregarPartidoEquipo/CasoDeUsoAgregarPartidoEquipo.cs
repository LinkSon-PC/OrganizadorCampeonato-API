using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using OrganizadorCampeonato.Dominio.Entidades;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.PartidoEquipos.Comandos.AgregarPartidoEquipo
{
    public class CasoDeUsoAgregarPartidoEquipo : IRequestHandler<ComandoAgregarPartidoEquipo, Guid>
    {
        private readonly IRepositorioPartidoEquipo repositorio;
        private readonly IRepositorioPartido repositorioPartido;
        private readonly IRepositorioEquipo repositorioEquipo;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoAgregarPartidoEquipo(
            IRepositorioPartidoEquipo repositorio,
            IRepositorioPartido repositorioPartido,
            IRepositorioEquipo repositorioEquipo,
            IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorio = repositorio;
            this.repositorioPartido = repositorioPartido;
            this.repositorioEquipo = repositorioEquipo;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task<Guid> Handle(ComandoAgregarPartidoEquipo request)
        {
            var partido = await repositorioPartido.ObtenerPorId(request.PartidoId);
            if (partido is null)
                throw new ExcepcionDeValidacion("No se encontro el partido");

            var equipo = await repositorioEquipo.ObtenerPorId(request.EquipoId);
            if (equipo is null)
                throw new ExcepcionDeValidacion("No se encontro el equipo");

            var partidoEquipo = new PartidoEquipo(
                Guid.CreateVersion7(),
                request.PartidoId,
                request.EquipoId,
                request.EsLocal);

            try
            {
                var respuesta = await repositorio.Agregar(partidoEquipo);
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
