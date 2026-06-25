using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.ResultadoPeriodos.Comandos.AgregarResultadoPeriodo;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.ResultadoPeriodos.Comandos.ActualizarResultadoPeriodo;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.ResultadoPeriodos.Comandos.EliminarResultadoPeriodo;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.ResultadoPeriodos.Consultas.ObtenerResultadoPeriodoPorId;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.ResultadoPeriodos.Consultas.ObtenerTodosResultadoPeriodos;
using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Modelos.ResultadoPeriodos;

namespace OrganizadorCampeonato.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultadoPeriodosController : ControllerBase
    {
        private readonly IMediator mediator;

        public ResultadoPeriodosController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var consulta = new ConsultaObtenerResultadoPeriodoPorId { Id = id };
            var resultado = await mediator.Send(consulta);
            return Ok(resultado);
        }

        [HttpGet]
        public async Task<ActionResult<List<ListadoResultadoPeriodoDTO>>> Get()
        {
            var consulta = new ConsultaObtenerTodosResultadoPeriodos();
            var resultados = await mediator.Send(consulta);
            return Ok(resultados);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Post([FromBody] AgregarResultadoPeriodoDTO dto)
        {
            var comando = new ComandoAgregarResultadoPeriodo
            {
                PartidoId = dto.PartidoId,
                Periodo = dto.Periodo,
                EquipoId = dto.EquipoId
            };

            var resultado = await mediator.Send(comando);
            return Ok(resultado);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] ActualizarResultadoPeriodoDTO dto)
        {
            var comando = new ComandoActualizarResultadoPeriodo
            {
                Id = id,
                PartidoId = dto.PartidoId,
                Periodo = dto.Periodo,
                EquipoId = dto.EquipoId
            };

            await mediator.Send(comando);
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var comando = new ComandoEliminarResultadoPeriodo { Id = id };
            await mediator.Send(comando);
            return Ok();
        }
    }
}
