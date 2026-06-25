using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.ResultadoPeriodos.Consultas.ObtenerTodosResultadoPeriodos
{
    public class CasoDeUsoObtenerTodosResultadoPeriodos : IRequestHandler<ConsultaObtenerTodosResultadoPeriodos, List<ListadoResultadoPeriodoDTO>>
    {
        private readonly IRepositorioResultadoPeriodo repositorio;

        public CasoDeUsoObtenerTodosResultadoPeriodos(IRepositorioResultadoPeriodo repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<List<ListadoResultadoPeriodoDTO>> Handle(ConsultaObtenerTodosResultadoPeriodos request)
        {
            var entities = await repositorio.ObtenerTodos();
            return entities.Select(x => x.ADto()).ToList();
        }
    }
}
