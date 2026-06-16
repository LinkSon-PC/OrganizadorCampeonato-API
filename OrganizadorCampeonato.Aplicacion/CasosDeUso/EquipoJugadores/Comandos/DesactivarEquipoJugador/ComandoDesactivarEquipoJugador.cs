using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.EquipoJugadores.Comandos.DesactivarEquipoJugador
{
    public record ComandoDesactivarEquipoJugador : IRequest
    {
        public required Guid Id { get; init; }
        public required Guid EquipoId { get; init; }
        public required Guid JugadorId { get; init; }
    }
}
