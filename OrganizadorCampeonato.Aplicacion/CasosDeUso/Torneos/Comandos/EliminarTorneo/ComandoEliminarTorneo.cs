using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Torneos.Comandos.EliminarTorneo
{
    public record ComandoEliminarTorneo : IRequest
    {
        public required Guid Id { get; init; }
    }
}
