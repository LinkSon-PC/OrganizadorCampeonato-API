using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.PartidoArbitros.Consultas.ObtenerTodosPartidoArbitros
{
    public class CasoDeUsoObtenerTodosPartidoArbitros : IRequestHandler<ConsultaObtenerTodosPartidoArbitros, List<ListadoPartidoArbitroDTO>>
    {
        private readonly IRepositorioPartidoArbitro repositorio;

        public CasoDeUsoObtenerTodosPartidoArbitros(IRepositorioPartidoArbitro repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<List<ListadoPartidoArbitroDTO>> Handle(ConsultaObtenerTodosPartidoArbitros request)
        {
            var entities = await repositorio.ObtenerTodos();
            return entities.Select(x => x.ADto()).ToList();
        }
    }
}
