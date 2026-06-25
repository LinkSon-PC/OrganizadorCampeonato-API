using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.TorneoEquipos.Comandos.EliminarTorneoEquipo
{
    public record ComandoEliminarTorneoEquipo : IRequest
    {
        public required Guid Id { get; init; }
    }
}
