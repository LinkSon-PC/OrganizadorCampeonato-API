using OrganizadorCampeonato.Aplicacion.CasosDeUso.Personas.Consultas.ObtenerTodos;
using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Personas.Consultas.ObtenerPorId
{
    public class CasoDeUsoObtenerPorId : IRequestHandler<ConsultaObtenerPersonaPorId, PersonaDTO>
    {
        private readonly IRepositorioPersona repositorio;

        public CasoDeUsoObtenerPorId(IRepositorioPersona repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<PersonaDTO> Handle(ConsultaObtenerPersonaPorId request)
        {
            var persoana = await repositorio.ObtenerPorId(request.Id);
            if (persoana is null)
                throw new ExcepcionDeValidacion("No se encontró la persona");

            return persoana.ADto();
        }
    }
}
