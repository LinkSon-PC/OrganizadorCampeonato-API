using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Dominio.Enum;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Partidos.Comandos.AgregarPartido
{
    public record ComandoAgregarPartido : IRequest<Guid>
    {
        public required DateTime FechaHora { get; init; }
        public required string Lugar { get; init; }
        public required Guid TorneoId { get; init; }
        public required FasePartido Fase { get; init; }
        public required int Jornada { get; init; }
        public string? Grupo { get; init; }
        public int? NumeroRondaKO { get; init; }
        public Guid? PartidoOrigenLocalId { get; init; }
        public Guid? PartidoOrigenVisitanteId { get; init; }
    }
}
