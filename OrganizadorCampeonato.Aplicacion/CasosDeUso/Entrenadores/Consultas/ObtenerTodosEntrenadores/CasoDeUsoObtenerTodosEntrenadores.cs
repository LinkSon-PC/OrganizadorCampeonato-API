using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Entrenadores.Consultas.ObtenerTodosEntrenadores
{
    public class CasoDeUsoObtenerTodosEntrenadores : IRequestHandler<ConsultaObtenerTodosEntrenadores, List<ListadoEntrenadorDTO>>
    {
        private readonly IRepositorioEntrenador repositorio;

        public CasoDeUsoObtenerTodosEntrenadores(IRepositorioEntrenador repositorio)
        {
            this.repositorio = repositorio;
        }

        public Task<List<ListadoEntrenadorDTO>> Handle(ConsultaObtenerTodosEntrenadores request)
        {
            var personas = repositorio.ObtenerTodosEntrenadores().Result
                .Select(p => p.Persona.ADto()).ToList();
            return Task.FromResult(personas);
        }
    }
}
