using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Partidos.Comandos.CompletarPartido
{
    public record ComandoCompletarPartido : IRequest
    {
        public required Guid Id { get; init; }
    }
}
