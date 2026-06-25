using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.PartidoArbitros.Comandos.ActualizarPartidoArbitro
{
    public record ComandoActualizarPartidoArbitro : IRequest
    {
        public required Guid Id { get; init; }
        public required Guid PartidoId { get; init; }
        public required Guid ArbitroId { get; init; }
        public string? Rol { get; init; }
    }
}
