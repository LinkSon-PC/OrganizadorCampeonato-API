using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.TorneoEquipos.Consultas.ObtenerTorneoEquipoPorId
{
    public record ConsultaObtenerTorneoEquipoPorId : IRequest<TorneoEquipoPorIdDTO>
    {
        public required Guid Id { get; init; }
    }
}
