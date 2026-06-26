using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Torneos.Comandos.GenerarLlaveEliminatoria
{
    public record ComandoGenerarLlaveEliminatoria : IRequest
    {
        public required Guid TorneoId { get; init; }
        public required DateTime FechaInicio { get; init; }
        public required string Lugar { get; init; }
    }
}
