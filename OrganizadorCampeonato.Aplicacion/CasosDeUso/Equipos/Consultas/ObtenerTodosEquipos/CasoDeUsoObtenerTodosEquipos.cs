using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Equipos.Consultas.ObtenerTodosEquipos
{
    public class CasoDeUsoObtenerTodosEquipos : IRequestHandler<ConsultaObtenerTodosEquipos, List<ListadoEquiposDTO>>
    {
        private readonly IRepositorioEquipo repositorio;

        public CasoDeUsoObtenerTodosEquipos(IRepositorioEquipo repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<List<ListadoEquiposDTO>> Handle(ConsultaObtenerTodosEquipos request)
        {
            var equipos = await repositorio.ObtenerTodos();
            return equipos.Select(e => e.ADto()).ToList();
        }
    }
}
