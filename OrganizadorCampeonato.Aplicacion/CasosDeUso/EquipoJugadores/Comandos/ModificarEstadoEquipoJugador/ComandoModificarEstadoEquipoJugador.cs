using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.EquipoJugadores.Comandos.ModificarEstadoEquipoJugador
{
    public record ComandoModificarEstadoEquipoJugador : IRequest
    {
        public required Guid EquipoId { get; init; }
        public required Guid JugadorId { get; init; }
        public required bool EstaActivo { get; init; }
    }
}
