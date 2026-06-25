using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.PartidoArbitros.Comandos.AgregarPartidoArbitro;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.PartidoArbitros.Comandos.ActualizarPartidoArbitro;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.PartidoArbitros.Comandos.EliminarPartidoArbitro;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.PartidoArbitros.Consultas.ObtenerPartidoArbitroPorId;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.PartidoArbitros.Consultas.ObtenerTodosPartidoArbitros;
using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Modelos.PartidoArbitros;

namespace OrganizadorCampeonato.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartidoArbitrosController : ControllerBase
    {
        private readonly IMediator mediator;

        public PartidoArbitrosController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var consulta = new ConsultaObtenerPartidoArbitroPorId { Id = id };
            var resultado = await mediator.Send(consulta);
            return Ok(resultado);
        }

        [HttpGet]
        public async Task<ActionResult<List<ListadoPartidoArbitroDTO>>> Get()
        {
            var consulta = new ConsultaObtenerTodosPartidoArbitros();
            var resultados = await mediator.Send(consulta);
            return Ok(resultados);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Post([FromBody] AgregarPartidoArbitroDTO dto)
        {
            var comando = new ComandoAgregarPartidoArbitro
            {
                PartidoId = dto.PartidoId,
                ArbitroId = dto.ArbitroId,
                Rol = dto.Rol
            };

            var resultado = await mediator.Send(comando);
            return Ok(resultado);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] ActualizarPartidoArbitroDTO dto)
        {
            var comando = new ComandoActualizarPartidoArbitro
            {
                Id = id,
                PartidoId = dto.PartidoId,
                ArbitroId = dto.ArbitroId,
                Rol = dto.Rol
            };

            await mediator.Send(comando);
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var comando = new ComandoEliminarPartidoArbitro { Id = id };
            await mediator.Send(comando);
            return Ok();
        }
    }
}
