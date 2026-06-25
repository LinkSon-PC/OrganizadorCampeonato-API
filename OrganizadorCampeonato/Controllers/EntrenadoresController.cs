using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.Entrenadores.Comandos.AgregarEntrenador;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.Entrenadores.Comandos.ActualizarEntrenador;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.Entrenadores.Comandos.EliminarEntrenador;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.Entrenadores.Consultas.ObtenerEntrenadorPorId;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.Entrenadores.Consultas.ObtenerTodosEntrenadores;
using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Modelos.Entrenadores;

namespace OrganizadorCampeonato.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntrenadoresController : ControllerBase
    {
        private readonly IMediator mediator;

        public EntrenadoresController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var consulta = new ConsultaObtenerEntrenadorPorId { Id = id };
            var entrenador = await mediator.Send(consulta);
            return Ok(entrenador);
        }

        [HttpGet]
        public async Task<ActionResult<List<ListadoEntrenadorDTO>>> Get()
        {
            var consulta = new ConsultaObtenerTodosEntrenadores();
            var entrenadores = await mediator.Send(consulta);
            return Ok(entrenadores);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Post([FromBody] AgregarEntrenadorDTO dto)
        {
            var comando = new ComandoAgregarEntrenador(
                dto.Identificacion,
                dto.Nombres,
                dto.Apellidos,
                dto.FechaNacimiento,
                dto.Telefono,
                dto.Genero);

            var resultado = await mediator.Send(comando);
            return Ok(resultado);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] ActualizarEntrenadorDTO dto)
        {
            var comando = new ComandoActualizarEntrenador
            {
                Id = id,
                Identificacion = dto.Identificacion,
                Nombres = dto.Nombres,
                Apellidos = dto.Apellidos,
                FechaNacimiento = dto.FechaNacimiento,
                Telefono = dto.Telefono,
                Genero = dto.Genero
            };

            await mediator.Send(comando);
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var comando = new ComandoEliminarEntrenador { Id = id };
            await mediator.Send(comando);
            return Ok();
        }
    }
}
