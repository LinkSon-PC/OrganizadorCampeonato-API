using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.Entrenadores.Comandos.AgregarEntrenador;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.Entrenadores.Consultas.ObtenerTodosEntrenadores;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.Jugadores.Comandos.AgregarJugador;
using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Modelos.Jugadores;

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

        [HttpGet]
        public async Task<ActionResult<List<ListadoEntrenadorDTO>>> Get()
        {
            var consulta = new ConsultaObtenerTodosEntrenadores();
            var entrenadores = await mediator.Send(consulta);
            return entrenadores;
        } 

        [HttpPost]
        public async Task<ActionResult<Guid>> Post([FromBody] AgregarEntrenadorDTO jugadorDTO)
        {
            var comando = new ComandoAgregarEntrenador(
                jugadorDTO.Identificacion,
                jugadorDTO.Nombres,
                jugadorDTO.Apellidos,
                jugadorDTO.FechaNacimiento,
                jugadorDTO.Telefono,
                jugadorDTO.Genero);

            var resultado = await mediator.Send(comando);
            return resultado;
        }
    }
}
