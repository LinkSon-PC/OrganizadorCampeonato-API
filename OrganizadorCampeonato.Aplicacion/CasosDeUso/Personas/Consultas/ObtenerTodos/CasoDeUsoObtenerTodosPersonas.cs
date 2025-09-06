using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Personas.Consultas.ObtenerTodos
{
    public class CasoDeUsoObtenerTodosPersonas : IRequestHandler<ConsultaObtenerTodosPersonas, List<ListadoPersonasDTO>>
    {
        private readonly IRepositorioPersona repositorio;

        public CasoDeUsoObtenerTodosPersonas(IRepositorioPersona repositorio)
        {
            this.repositorio = repositorio;
        }

        public Task<List<ListadoPersonasDTO>> Handle(ConsultaObtenerTodosPersonas request)
        {
            var personas = repositorio.ObtenerTodos().Result.Select(x => x.ADto()).ToList();
            return Task.FromResult(personas);
        }
    }
}
