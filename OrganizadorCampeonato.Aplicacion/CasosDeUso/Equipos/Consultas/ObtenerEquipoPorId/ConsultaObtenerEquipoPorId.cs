using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Equipos.Consultas.ObtenerEquipoPorId
{
    public record ConsultaObtenerEquipoPorId : IRequest<EquipoDTO>
    {
        public required Guid Id { get; init; }
    }
}
