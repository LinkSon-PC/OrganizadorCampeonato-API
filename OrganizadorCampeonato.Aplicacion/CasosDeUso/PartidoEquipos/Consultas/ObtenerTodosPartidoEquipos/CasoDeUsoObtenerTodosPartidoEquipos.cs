using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.PartidoEquipos.Consultas.ObtenerTodosPartidoEquipos
{
    public class CasoDeUsoObtenerTodosPartidoEquipos : IRequestHandler<ConsultaObtenerTodosPartidoEquipos, List<ListadoPartidoEquipoDTO>>
    {
        private readonly IRepositorioPartidoEquipo repositorio;

        public CasoDeUsoObtenerTodosPartidoEquipos(IRepositorioPartidoEquipo repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<List<ListadoPartidoEquipoDTO>> Handle(ConsultaObtenerTodosPartidoEquipos request)
        {
            var entities = await repositorio.ObtenerTodos();
            return entities.Select(x => x.ADto()).ToList();
        }
    }
}
