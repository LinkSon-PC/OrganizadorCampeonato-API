using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Partidos.Comandos.EliminarPartido
{
    public record ComandoEliminarPartido : IRequest
    {
        public required Guid Id { get; init; }
    }
}
