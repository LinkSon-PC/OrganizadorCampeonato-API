using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.PartidoArbitros.Comandos.AgregarPartidoArbitro
{
    public record ComandoAgregarPartidoArbitro : IRequest<Guid>
    {
        public required Guid PartidoId { get; init; }
        public required Guid ArbitroId { get; init; }
        public string? Rol { get; init; }
    }
}
