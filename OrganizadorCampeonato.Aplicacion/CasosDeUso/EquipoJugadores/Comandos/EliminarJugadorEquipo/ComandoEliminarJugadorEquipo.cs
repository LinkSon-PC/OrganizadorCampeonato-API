using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.EquipoJugadores.Comandos.EliminarJugadorEquipo
{
    public record ComandoEliminarJugadorEquipo : IRequest
    {
        public required Guid Id { get; init; }
    }
}
