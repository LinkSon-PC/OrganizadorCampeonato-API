using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using OrganizadorCampeonato.Dominio.Entidades;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.OficialesPartido.Comandos.AgregarOficialPartido
{
    public class CasoDeUsoAgregarOficialPartido : IRequestHandler<ComandoAgregarOficialPartido, Guid>
    {
        private readonly IRepositorioOficialPartido repositorio;
        private readonly IRepositorioPartido repositorioPartido;
        private readonly IRepositorioArbitro repositorioArbitro;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoAgregarOficialPartido(
            IRepositorioOficialPartido repositorio,
            IRepositorioPartido repositorioPartido,
            IRepositorioArbitro repositorioArbitro,
            IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorio = repositorio;
            this.repositorioPartido = repositorioPartido;
            this.repositorioArbitro = repositorioArbitro;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task<Guid> Handle(ComandoAgregarOficialPartido request)
        {
            var partido = await repositorioPartido.ObtenerPorId(request.PartidoId);
            if (partido is null)
                throw new ExcepcionDeValidacion("No se encontro el partido");

            var arbitro = await repositorioArbitro.ObtenerPorId(request.ArbitroId);
            if (arbitro is null)
                throw new ExcepcionDeValidacion("No se encontro el arbitro");

            var oficialPartido = new OficialPartido(
                Guid.CreateVersion7(),
                request.PartidoId,
                request.ArbitroId,
                request.Rol);

            try
            {
                var respuesta = await repositorio.Agregar(oficialPartido);
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
