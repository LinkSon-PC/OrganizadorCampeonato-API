using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.Jugadores.Comandos.AgregarJugador;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.Jugadores.Comandos.ActualizarJugador;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.Jugadores.Comandos.EliminarJugador;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.Jugadores.Consultas.ObtenerJugadorPorId;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.Jugadores.Consultas.ObtenerTodosJugadores;
using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Modelos.Jugadores;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JugadoresController : ControllerBase
    {
        private readonly IMediator mediator;

        public JugadoresController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var consulta = new ConsultaObtenerJugadorPorId { Id = id };
            var jugador = await mediator.Send(consulta);
            return Ok(jugador);
        }

        [HttpGet]
        public async Task<ActionResult<List<JugadorDTO>>> Get()
        {
            var consulta = new ConsultaObtenerTodosJugadores();
            var jugadores = await mediator.Send(consulta);
            return Ok(jugadores);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Post([FromBody] AgregarJugadorDTO dto)
        {
            var comando = new ComandoAgregarJugador
            {
                Identificacion = dto.Identificacion,
                Nombres = dto.Nombres,
                Apellidos = dto.Apellidos,
                FechaNaciemiento = dto.FechaNacimiento,
                Telefono = dto.Telefono,
                Genero = dto.Genero,
            };
            var resultado = await mediator.Send(comando);
            return Ok(resultado);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] ActualizarJugadorDTO dto)
        {
            var comando = new ComandoActualizarJugador
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
            var comando = new ComandoEliminarJugador { Id = id };
            await mediator.Send(comando);
            return Ok();
        }
    }
}
