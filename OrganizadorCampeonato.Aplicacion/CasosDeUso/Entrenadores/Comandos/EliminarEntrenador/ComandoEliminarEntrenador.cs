using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Entrenadores.Comandos.EliminarEntrenador
{
    public record ComandoEliminarEntrenador : IRequest
    {
        public required Guid Id { get; init; }
    }
}
