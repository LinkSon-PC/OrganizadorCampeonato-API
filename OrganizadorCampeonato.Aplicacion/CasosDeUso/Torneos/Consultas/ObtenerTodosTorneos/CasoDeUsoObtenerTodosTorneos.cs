using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Torneos.Consultas.ObtenerTodosTorneos
{
    public class CasoDeUsoObtenerTodosTorneos : IRequestHandler<ConsultaObtenerTodosTorneos, List<ListadoTorneoDTO>>
    {
        private readonly IRepositorioTorneo repositorio;

        public CasoDeUsoObtenerTodosTorneos(IRepositorioTorneo repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<List<ListadoTorneoDTO>> Handle(ConsultaObtenerTodosTorneos request)
        {
            var entities = await repositorio.ObtenerTodos();
            return entities.Select(x => x.ADto()).ToList();
        }
    }
}
