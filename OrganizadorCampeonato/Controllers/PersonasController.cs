using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.Personas.Comandos.ActualizarPersona;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.Personas.Comandos.AgregarPersona;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.Personas.Consultas.ObtenerPorId;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.Personas.Consultas.ObtenerTodos;
using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Dominio.Enum;
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
        public async Task<ActionResult<List<ListadoPersonasDTO>>> Get([FromQuery] ConsultaObtenerTodosPersonas consulta)
        {
            var resultado = await mediator.Send(consulta);
            HttpContext.Response.Headers.Append("X-Total-count", resultado.Total.ToString());
            return resultado.Elementos;
        }

        // GET api/<PersonasController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var consulta = new ConsultaObtenerPersonaPorId{ Id = id};
            var persona = await mediator.Send(consulta);
            return Ok(persona);
        }

        // POST api/<PersonasController>
        [HttpPost]
        public async Task<ActionResult<Guid>> Post([FromBody] AgregarJugadorDTO value)
        {
            var comando = new ComandoAgregarPersona
            {
                Identificacion = value.Identificacion,
                Nombres = value.Nombres,
                Apellidos = value.Apellidos,
                FechaNaciemiento = value.FechaNacimiento,
                Telefono = value.Telefono,
                Genero = value.Genero,
            };
            var resultado = await mediator.Send(comando);
            return resultado;
        }

        // PUT api/<PersonasController>/5
        [HttpPut("{id}")]
        public async Task Put(Guid id, [FromBody] ActualizarPersona personaDto)
        {
            var comando = new ComandoActualizarPersona
            {
                Id = id,
                Identificacion = personaDto.Identificacion,
                Nombres = personaDto.Nombres,
                Apellidos = personaDto.Apellidos,
                Telefono = personaDto.Telefono,
                Genero = TipoGenero.Masculino,
                FechaNaciemiento = personaDto.FechaNacimiento
            };
            await mediator.Send(comando);
        }

        // DELETE api/<PersonasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
