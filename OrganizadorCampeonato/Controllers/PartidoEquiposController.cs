using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.PartidoEquipos.Comandos.AgregarPartidoEquipo;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.PartidoEquipos.Comandos.ActualizarPartidoEquipo;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.PartidoEquipos.Comandos.EliminarPartidoEquipo;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.PartidoEquipos.Comandos.MarcarGanadorPartidoEquipo;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.PartidoEquipos.Consultas.ObtenerPartidoEquipoPorId;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.PartidoEquipos.Consultas.ObtenerTodosPartidoEquipos;
using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Modelos.PartidoEquipos;

namespace OrganizadorCampeonato.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartidoEquiposController : ControllerBase
    {
        private readonly IMediator mediator;

        public PartidoEquiposController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var consulta = new ConsultaObtenerPartidoEquipoPorId { Id = id };
            var resultado = await mediator.Send(consulta);
            return Ok(resultado);
        }

        [HttpGet]
        public async Task<ActionResult<List<ListadoPartidoEquipoDTO>>> Get()
        {
            var consulta = new ConsultaObtenerTodosPartidoEquipos();
            var resultados = await mediator.Send(consulta);
            return Ok(resultados);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Post([FromBody] AgregarPartidoEquipoDTO dto)
        {
            var comando = new ComandoAgregarPartidoEquipo
            {
                PartidoId = dto.PartidoId,
                EquipoId = dto.EquipoId,
                EsLocal = dto.EsLocal
            };

            var resultado = await mediator.Send(comando);
            return Ok(resultado);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] ActualizarPartidoEquipoDTO dto)
        {
            var comando = new ComandoActualizarPartidoEquipo
            {
                Id = id,
                PartidoId = dto.PartidoId,
                EquipoId = dto.EquipoId,
                EsLocal = dto.EsLocal,
                EsGanador = dto.EsGanador
            };

            await mediator.Send(comando);
            return Ok();
        }

        [HttpPost("{id:guid}/marcar-ganador")]
        public async Task<ActionResult> MarcarGanador(Guid id, [FromBody] MarcarGanadorDTO dto)
        {
            var comando = new ComandoMarcarGanadorPartidoEquipo
            {
                Id = id,
                PartidoId = dto.PartidoId,
                EquipoId = dto.EquipoId,
                EsLocal = dto.EsLocal,
                EsGanador = dto.EsGanador
            };

            await mediator.Send(comando);
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var comando = new ComandoEliminarPartidoEquipo { Id = id };
            await mediator.Send(comando);
            return Ok();
        }
    }
}
