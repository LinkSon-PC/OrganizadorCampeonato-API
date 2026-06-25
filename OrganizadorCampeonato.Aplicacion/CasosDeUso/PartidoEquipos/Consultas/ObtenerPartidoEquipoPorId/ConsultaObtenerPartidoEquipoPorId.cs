using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.PartidoEquipos.Consultas.ObtenerPartidoEquipoPorId
{
    public record ConsultaObtenerPartidoEquipoPorId : IRequest<PartidoEquipoDTO>
    {
        public required Guid Id { get; init; }
    }
}
