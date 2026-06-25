using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.TorneoEquipos.Comandos.EliminarTorneoEquipo;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.TorneoEquipos.Comandos.InscribirEquipo;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.TorneoEquipos.Consultas.ObtenerEquiposPorTorneo;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.TorneoEquipos.Consultas.ObtenerTorneoEquipoPorId;
using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Modelos.TorneoEquipos;

namespace OrganizadorCampeonato.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TorneoEquiposController : ControllerBase
    {
        private readonly IMediator mediator;

        public TorneoEquiposController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var consulta = new ConsultaObtenerTorneoEquipoPorId { Id = id };
            var resultado = await mediator.Send(consulta);
            return Ok(resultado);
        }

        [HttpGet("torneo/{torneoId:guid}")]
        public async Task<ActionResult<List<TorneoEquipoDTO>>> GetByTorneo(Guid torneoId)
        {
            var consulta = new ConsultaObtenerEquiposPorTorneo { TorneoId = torneoId };
            var resultados = await mediator.Send(consulta);
            return Ok(resultados);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] InscribirEquipoDTO dto)
        {
            var comando = new ComandoInscribirEquipo
            {
                Id = Guid.CreateVersion7(),
                TorneoId = dto.TorneoId,
                EquipoId = dto.EquipoId
            };

            await mediator.Send(comando);
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var comando = new ComandoEliminarTorneoEquipo { Id = id };
            await mediator.Send(comando);
            return Ok();
        }
    }
}
