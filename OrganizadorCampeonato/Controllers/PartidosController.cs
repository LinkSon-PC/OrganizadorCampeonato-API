using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.Partidos.Comandos.AgregarPartido;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.Partidos.Comandos.CancelarPartido;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.Partidos.Comandos.CompletarPartido;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.Partidos.Comandos.EliminarPartido;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.Partidos.Consultas.ObtenerPartidoPorId;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.Partidos.Consultas.ObtenerTodosPartidos;
using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Modelos.Partidos;

namespace OrganizadorCampeonato.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartidosController : ControllerBase
    {
        private readonly IMediator mediator;

        public PartidosController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var consulta = new ConsultaObtenerPartidoPorId { Id = id };
            var partido = await mediator.Send(consulta);
            return Ok(partido);
        }

        [HttpGet]
        public async Task<ActionResult<List<ListadoPartidoDTO>>> Get()
        {
            var consulta = new ConsultaObtenerTodosPartidos();
            var partidos = await mediator.Send(consulta);
            return Ok(partidos);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Post([FromBody] AgregarPartidoDTO dto)
        {
            var comando = new ComandoAgregarPartido
            {
                FechaHora = dto.FechaHora,
                Lugar = dto.Lugar,
                TorneoId = dto.TorneoId,
                Ronda = dto.Ronda,
                Grupo = dto.Grupo
            };

            var resultado = await mediator.Send(comando);
            return Ok(resultado);
        }

        [HttpPost("{id:guid}/completar")]
        public async Task<ActionResult> Completar(Guid id, [FromBody] CompletarPartidoDTO dto)
        {
            var comando = new ComandoCompletarPartido
            {
                Id = id,
                FechaHora = dto.FechaHora,
                Lugar = dto.Lugar,
                TorneoId = dto.TorneoId,
                Ronda = dto.Ronda,
                Grupo = dto.Grupo,
                GanadorId = dto.GanadorId,
                PuntosLocal_P1 = dto.PuntosLocal_P1,
                PuntosVisitante_P1 = dto.PuntosVisitante_P1,
                PuntosLocal_P2 = dto.PuntosLocal_P2,
                PuntosVisitante_P2 = dto.PuntosVisitante_P2,
                PuntosLocal_P3 = dto.PuntosLocal_P3,
                PuntosVisitante_P3 = dto.PuntosVisitante_P3,
                PuntosLocal_P4 = dto.PuntosLocal_P4,
                PuntosVisitante_P4 = dto.PuntosVisitante_P4,
                PuntosLocal_Prorroga = dto.PuntosLocal_Prorroga,
                PuntosVisitante_Prorroga = dto.PuntosVisitante_Prorroga,
                PuntosLocal_Prorroga2 = dto.PuntosLocal_Prorroga2,
                PuntosVisitante_Prorroga2 = dto.PuntosVisitante_Prorroga2
            };

            await mediator.Send(comando);
            return Ok();
        }

        [HttpPost("{id:guid}/cancelar")]
        public async Task<ActionResult> Cancelar(Guid id, [FromBody] CompletarPartidoDTO dto)
        {
            var comando = new ComandoCancelarPartido
            {
                Id = id,
                FechaHora = dto.FechaHora,
                Lugar = dto.Lugar,
                TorneoId = dto.TorneoId,
                Ronda = dto.Ronda,
                Grupo = dto.Grupo
            };

            await mediator.Send(comando);
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var comando = new ComandoEliminarPartido { Id = id };
            await mediator.Send(comando);
            return Ok();
        }
    }
}
