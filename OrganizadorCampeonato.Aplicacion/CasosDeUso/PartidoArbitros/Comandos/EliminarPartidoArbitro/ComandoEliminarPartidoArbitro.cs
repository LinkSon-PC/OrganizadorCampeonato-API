using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.PartidoArbitros.Comandos.EliminarPartidoArbitro
{
    public record ComandoEliminarPartidoArbitro : IRequest
    {
        public required Guid Id { get; init; }
    }
}
