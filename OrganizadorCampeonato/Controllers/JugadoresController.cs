using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.Jugadores.Comandos.AgregarJugador;
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

        [HttpGet]
        public async Task<ActionResult<List<JugadorDTO>>> Get()
        {
            var consulta = new ConsultaObtenerTodosJugadores();
            var jugadores = await mediator.Send(consulta);
            return jugadores;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Post([FromBody] AgregarJugadorDTO jugadorDTO)
        {
            var comando = new ComandoAgregarJugador
            {
                Identificacion = jugadorDTO.Identificacion,
                Nombres = jugadorDTO.Nombres,
                Apellidos = jugadorDTO.Apellidos,
                Telefono = jugadorDTO.Telefono,
                FechaNaciemiento = jugadorDTO.FechaNacimiento
            };
            var resultado = await mediator.Send(comando);
            return resultado;
        }
    }
}
