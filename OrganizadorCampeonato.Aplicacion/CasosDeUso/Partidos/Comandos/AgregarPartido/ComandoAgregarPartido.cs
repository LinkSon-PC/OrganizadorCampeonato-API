using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Partidos.Comandos.AgregarPartido
{
    public record ComandoAgregarPartido : IRequest<Guid>
    {
        public required DateTime FechaHora { get; init; }
        public required string Lugar { get; init; }
        public required Guid TorneoId { get; init; }
        public required int Ronda { get; init; }
        public string? Grupo { get; init; }
    }
}
