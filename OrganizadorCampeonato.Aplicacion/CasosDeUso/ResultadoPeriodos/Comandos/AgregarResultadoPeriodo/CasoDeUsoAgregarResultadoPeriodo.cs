using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using OrganizadorCampeonato.Dominio.Entidades;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.ResultadoPeriodos.Comandos.AgregarResultadoPeriodo
{
    public class CasoDeUsoAgregarResultadoPeriodo : IRequestHandler<ComandoAgregarResultadoPeriodo, Guid>
    {
        private readonly IRepositorioResultadoPeriodo repositorio;
        private readonly IRepositorioPartido repositorioPartido;
        private readonly IRepositorioEquipo repositorioEquipo;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoAgregarResultadoPeriodo(
            IRepositorioResultadoPeriodo repositorio,
            IRepositorioPartido repositorioPartido,
            IRepositorioEquipo repositorioEquipo,
            IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorio = repositorio;
            this.repositorioPartido = repositorioPartido;
            this.repositorioEquipo = repositorioEquipo;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task<Guid> Handle(ComandoAgregarResultadoPeriodo request)
        {
            var partido = await repositorioPartido.ObtenerPorId(request.PartidoId);
            if (partido is null)
                throw new ExcepcionDeValidacion("No se encontro el partido");

            var equipo = await repositorioEquipo.ObtenerPorId(request.EquipoId);
            if (equipo is null)
                throw new ExcepcionDeValidacion("No se encontro el equipo");

            var resultadoPeriodo = new ResultadoPeriodo(
                Guid.CreateVersion7(),
                request.PartidoId,
                request.Periodo,
                request.EquipoId);

            try
            {
                var respuesta = await repositorio.Agregar(resultadoPeriodo);
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
