using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.PartidoEquipos.Comandos.AgregarPartidoEquipo
{
    public record ComandoAgregarPartidoEquipo : IRequest<Guid>
    {
        public required Guid PartidoId { get; init; }
        public required Guid EquipoId { get; init; }
        public required bool EsLocal { get; init; }
    }
}
