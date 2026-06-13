using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.Equipos.Comandos.ActualizarEquipo;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.Equipos.Comandos.AgregarEquipo;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.Equipos.Consultas.ObtenerEquipoPorId;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.Equipos.Consultas.ObtenerTodosEquipos;
using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Modelos.Equipos;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquiposController : ControllerBase
    {
        private readonly IMediator mediator;

        public EquiposController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> Get(Guid id) 
        {
            var consulta = new ConsultaObtenerEquipoPorId { Id = id };
            var equipo = await mediator.Send(consulta);
            return Ok(equipo);
        }

        [HttpGet]
        public async Task<ActionResult<ListadoEquiposDTO>> Get()
        {
            var consulta = new ConsultaObtenerTodosEquipos();
            var equipos = await mediator.Send(consulta);
            return Ok(equipos);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Post([FromBody] AgregarEquipoDTO request)
        {
            var comando = new ComandoAgregarEquipo
            {
                Nombre = request.Nombre,
                EntrenadorId = request.EntrenadorId,
                CategoriaId = request.CategoriaId
            };

            var id = await mediator.Send(comando);
            return Ok(id);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> Post(Guid id, [FromBody] ActualizarEquipoDTO request)
        {
            var comando = new ComandoActualizarEquipo
            {
                Id = id,
                Nombre = request.Nombre,
                EntrenadorId = request.EntrenadorId,
                CategoriaId = request.CategoriaId
            };

            await mediator.Send(comando);
            return Ok();
        }
    }
}
