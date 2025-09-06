using OrganizadorCampeonato.Aplicacion.CasosDeUso.Personas.Consultas.ObtenerTodos;
using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Personas.Consultas.ObtenerPorId
{
    public class ConsultaObtenerPersonaPorId : IRequest<PersonaDTO>
    {
        public Guid Id { get; set; }
    }
}
