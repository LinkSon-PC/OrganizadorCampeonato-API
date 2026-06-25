using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.PartidoEquipos.Comandos.ActualizarPartidoEquipo
{
    public record ComandoActualizarPartidoEquipo : IRequest
    {
        public required Guid Id { get; init; }
        public required Guid PartidoId { get; init; }
        public required Guid EquipoId { get; init; }
        public required bool EsLocal { get; init; }
        public required bool EsGanador { get; init; }
    }
}
