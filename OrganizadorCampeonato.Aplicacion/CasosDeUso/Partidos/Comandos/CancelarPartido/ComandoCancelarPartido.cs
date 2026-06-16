using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Partidos.Comandos.CancelarPartido
{
    public record ComandoCancelarPartido : IRequest
    {
        public required Guid Id { get; init; }
        public required DateTime FechaHora { get; init; }
        public required string Lugar { get; init; }
        public required Guid TorneoId { get; init; }
        public required int Ronda { get; init; }
        public string? Grupo { get; init; }
    }
}
