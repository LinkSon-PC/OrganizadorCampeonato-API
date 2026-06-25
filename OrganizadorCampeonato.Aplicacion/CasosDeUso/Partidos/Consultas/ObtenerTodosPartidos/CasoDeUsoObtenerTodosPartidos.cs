using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Partidos.Consultas.ObtenerTodosPartidos
{
    public class CasoDeUsoObtenerTodosPartidos : IRequestHandler<ConsultaObtenerTodosPartidos, List<ListadoPartidoDTO>>
    {
        private readonly IRepositorioPartido repositorio;

        public CasoDeUsoObtenerTodosPartidos(IRepositorioPartido repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<List<ListadoPartidoDTO>> Handle(ConsultaObtenerTodosPartidos request)
        {
            var entities = await repositorio.ObtenerTodos();
            return entities.Select(x => x.ADto()).ToList();
        }
    }
}
