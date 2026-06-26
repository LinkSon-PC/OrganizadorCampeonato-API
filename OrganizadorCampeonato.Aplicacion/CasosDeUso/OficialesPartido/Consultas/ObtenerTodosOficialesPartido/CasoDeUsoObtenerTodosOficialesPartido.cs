using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.OficialesPartido.Consultas.ObtenerTodosOficialesPartido
{
    public class CasoDeUsoObtenerTodosOficialesPartido : IRequestHandler<ConsultaObtenerTodosOficialesPartido, List<ListadoOficialPartidoDTO>>
    {
        private readonly IRepositorioOficialPartido repositorio;

        public CasoDeUsoObtenerTodosOficialesPartido(IRepositorioOficialPartido repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<List<ListadoOficialPartidoDTO>> Handle(ConsultaObtenerTodosOficialesPartido request)
        {
            var entities = await repositorio.ObtenerTodos();
            return entities.Select(x => x.ADto()).ToList();
        }
    }
}
