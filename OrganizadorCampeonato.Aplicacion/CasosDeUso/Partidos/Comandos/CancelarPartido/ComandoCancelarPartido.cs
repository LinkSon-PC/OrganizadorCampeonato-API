using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Partidos.Comandos.CancelarPartido
{
    public record ComandoCancelarPartido : IRequest
    {
        public required Guid Id { get; init; }
    }
}
