using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.PartidoEquipos.Comandos.EliminarPartidoEquipo
{
    public record ComandoEliminarPartidoEquipo : IRequest
    {
        public required Guid Id { get; init; }
    }
}
