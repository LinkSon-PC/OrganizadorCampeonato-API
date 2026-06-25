using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Jugadores.Comandos.EliminarJugador
{
    public record ComandoEliminarJugador : IRequest
    {
        public required Guid Id { get; init; }
    }
}
