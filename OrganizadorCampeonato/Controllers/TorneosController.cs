using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.Torneos.Comandos.AgregarTorneos;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.Torneos.Comandos.ActualizarTorneos;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.Torneos.Comandos.EliminarTorneo;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.Torneos.Comandos.GenerarFixtureGrupos;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.Torneos.Comandos.GenerarLlaveEliminatoria;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.Torneos.Consultas.ObtenerTorneoPorId;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.Torneos.Consultas.ObtenerTodosTorneos;
using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Modelos.Torneos;

namespace OrganizadorCampeonato.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TorneosController : ControllerBase
    {
        private readonly IMediator mediator;

        public TorneosController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var consulta = new ConsultaObtenerTorneoPorId { Id = id };
            var torneo = await mediator.Send(consulta);
            return Ok(torneo);
        }

        [HttpGet]
        public async Task<ActionResult<List<ListadoTorneoDTO>>> Get()
        {
            var consulta = new ConsultaObtenerTodosTorneos();
            var torneos = await mediator.Send(consulta);
            return Ok(torneos);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AgregarTorneoDTO dto)
        {
            var comando = new ComandoAgregarTorneo
            {
                Nombre = dto.Nombre,
                Lugar = dto.Lugar,
                Descripcion = dto.Descripcion,
                CategoriaId = dto.CategoriaId,
                Formato = dto.Formato,
                FechaInicio = dto.FechaInicio,
                FechaFin = dto.FechaFin
            };

            await mediator.Send(comando);
            return Ok();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] ActualizarTorneoDTO dto)
        {
            var comando = new ComandoActualizarTorneo
            {
                Id = id,
                Nombre = dto.Nombre,
                Lugar = dto.Lugar,
                Descripcion = dto.Descripcion,
                CategoriaId = dto.CategoriaId,
                Formato = dto.Formato,
                FechaInicio = dto.FechaInicio,
                FechaFin = dto.FechaFin
            };

            await mediator.Send(comando);
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var comando = new ComandoEliminarTorneo { Id = id };
            await mediator.Send(comando);
            return Ok();
        }

        [HttpPost("{id:guid}/generar-fixture-grupos")]
        public async Task<ActionResult> GenerarFixtureGrupos(Guid id, [FromBody] GenerarFixtureGruposDTO dto)
        {
            var comando = new ComandoGenerarFixtureGrupos
            {
                TorneoId = id,
                FechaInicio = dto.FechaInicio,
                Lugar = dto.Lugar
            };

            await mediator.Send(comando);
            return Ok();
        }

        [HttpPost("{id:guid}/generar-llave-eliminatoria")]
        public async Task<ActionResult> GenerarLlaveEliminatoria(Guid id, [FromBody] GenerarLlaveEliminatoriaDTO dto)
        {
            var comando = new ComandoGenerarLlaveEliminatoria
            {
                TorneoId = id,
                FechaInicio = dto.FechaInicio,
                Lugar = dto.Lugar
            };

            await mediator.Send(comando);
            return Ok();
        }
    }
}
