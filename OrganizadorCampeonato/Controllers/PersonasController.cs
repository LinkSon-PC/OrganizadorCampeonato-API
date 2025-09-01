using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.Personas.Comandos.AgregarPersona;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.Personas.Consultas.ObtenerTodos;
using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Dominio.Entidades;
using OrganizadorCampeonato.Modelos.Personas;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrganizadorCampeonato.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly IMediator mediator;

        public PersonasController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: api/<PersonasController>
        [HttpGet]
        public async Task<ActionResult<List<PersonaDTO>>> Get()
        {
            var consulta = new ConsultaObtenerTodosPersonas();
            var resultado = await mediator.Send(consulta);
            return resultado;
        }

        // GET api/<PersonasController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PersonasController>
        [HttpPost]
        public async Task<ActionResult<Guid>> Post([FromBody] AgregarPersonaDTO value)
        {
            var comando = new ComandoAgregarPersona
            {
                Identificacion = value.Identificacion,
                Nombres = value.Nombres,
                Apellidos = value.Apellidos,
                FechaNaciemiento = value.FechaNaciemiento,
                Telefono = value.Telefono
            };
            var resultado = await mediator.Send(comando);
            return resultado;
        }

        // PUT api/<PersonasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PersonasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
