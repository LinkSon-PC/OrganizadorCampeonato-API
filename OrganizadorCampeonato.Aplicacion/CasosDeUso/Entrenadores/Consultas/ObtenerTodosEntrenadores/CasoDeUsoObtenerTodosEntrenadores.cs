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

        public async Task<List<ListadoEntrenadorDTO>> Handle(ConsultaObtenerTodosEntrenadores request)
        {
            var personas = await repositorio.ObtenerTodosEntrenadores();
            return personas.Select(p => p.Persona.ADto()).ToList();
        }
    }
}
