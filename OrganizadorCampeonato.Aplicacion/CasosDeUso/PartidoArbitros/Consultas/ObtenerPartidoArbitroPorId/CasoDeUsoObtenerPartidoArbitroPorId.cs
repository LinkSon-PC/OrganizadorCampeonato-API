using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.PartidoArbitros.Consultas.ObtenerPartidoArbitroPorId
{
    public class CasoDeUsoObtenerPartidoArbitroPorId : IRequestHandler<ConsultaObtenerPartidoArbitroPorId, PartidoArbitroDTO>
    {
        private readonly IRepositorioPartidoArbitro repositorio;

        public CasoDeUsoObtenerPartidoArbitroPorId(IRepositorioPartidoArbitro repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<PartidoArbitroDTO> Handle(ConsultaObtenerPartidoArbitroPorId request)
        {
            var entity = await repositorio.ObtenerPorId(request.Id);
            if (entity is null)
                throw new ExcepcionDeValidacion("No se encontro la relacion partido-arbitro");

            return entity.ADto();
        }
    }
}
