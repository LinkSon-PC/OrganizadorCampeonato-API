using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.EquipoJugadores.Comandos.InscribirJugador
{
    public record ComandoInscribirJugador : IRequest
    {
        public required Guid EquipoId { get; init; }
        public required Guid JugadorId { get; init; }
    }
}
