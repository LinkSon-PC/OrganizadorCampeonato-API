using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.OficialesPartido.Consultas.ObtenerOficialPartidoPorId
{
    public class CasoDeUsoObtenerOficialPartidoPorId : IRequestHandler<ConsultaObtenerOficialPartidoPorId, OficialPartidoDTO>
    {
        private readonly IRepositorioOficialPartido repositorio;

        public CasoDeUsoObtenerOficialPartidoPorId(IRepositorioOficialPartido repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<OficialPartidoDTO> Handle(ConsultaObtenerOficialPartidoPorId request)
        {
            var entity = await repositorio.ObtenerPorId(request.Id);
            if (entity is null)
                throw new ExcepcionDeValidacion("No se encontro la relacion partido-oficial");

            return entity.ADto();
        }
    }
}
