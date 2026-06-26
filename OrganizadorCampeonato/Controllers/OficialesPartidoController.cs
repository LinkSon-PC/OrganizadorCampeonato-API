using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.OficialesPartido.Comandos.AgregarOficialPartido;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.OficialesPartido.Comandos.ActualizarOficialPartido;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.OficialesPartido.Comandos.EliminarOficialPartido;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.OficialesPartido.Consultas.ObtenerOficialPartidoPorId;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.OficialesPartido.Consultas.ObtenerTodosOficialesPartido;
using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Modelos.OficialesPartido;

namespace OrganizadorCampeonato.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OficialesPartidoController : ControllerBase
    {
        private readonly IMediator mediator;

        public OficialesPartidoController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var consulta = new ConsultaObtenerOficialPartidoPorId { Id = id };
            var resultado = await mediator.Send(consulta);
            return Ok(resultado);
        }

        [HttpGet]
        public async Task<ActionResult<List<ListadoOficialPartidoDTO>>> Get()
        {
            var consulta = new ConsultaObtenerTodosOficialesPartido();
            var resultados = await mediator.Send(consulta);
            return Ok(resultados);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Post([FromBody] AgregarOficialPartidoDTO dto)
        {
            var comando = new ComandoAgregarOficialPartido
            {
                PartidoId = dto.PartidoId,
                ArbitroId = dto.ArbitroId,
                Rol = dto.Rol
            };

            var resultado = await mediator.Send(comando);
            return Ok(resultado);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] ActualizarOficialPartidoDTO dto)
        {
            var comando = new ComandoActualizarOficialPartido
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
            var comando = new ComandoEliminarOficialPartido { Id = id };
            await mediator.Send(comando);
            return Ok();
        }
    }
}
