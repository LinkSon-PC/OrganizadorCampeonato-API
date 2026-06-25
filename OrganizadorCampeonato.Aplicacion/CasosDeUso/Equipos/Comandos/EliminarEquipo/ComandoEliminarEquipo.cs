using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Equipos.Comandos.EliminarEquipo
{
    public record ComandoEliminarEquipo : IRequest
    {
        public required Guid Id { get; init; }
    }
}
