using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.TorneoEquipos.Comandos.InscribirEquipo
{
    public record ComandoInscribirEquipo : IRequest
    {
        public required Guid Id { get; init; }
        public required Guid TorneoId { get; init; }
        public required Guid EquipoId { get; init; }
        public int? Posicion { get; init; }
    }
}
