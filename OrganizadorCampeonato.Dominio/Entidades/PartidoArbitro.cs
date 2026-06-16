using OrganizadorCampeonato.Dominio.Comunes;
using System;

namespace OrganizadorCampeonato.Dominio.Entidades
{
    public class PartidoArbitro : EntidadAuditable<Guid>
    {
        private PartidoArbitro() { }

        public PartidoArbitro(Guid id, Guid partidoId, Guid arbitroId, string? rol) : base(id)
        {
            PartidoId = partidoId;
            ArbitroId = arbitroId;
            Rol = rol;
        }

        public Guid PartidoId { get; init; }
        public Guid ArbitroId { get; init; }
        public string? Rol { get; init; }

        public Partido Partido { get; init; } = null!;
        public Arbitro Arbitro { get; init; } = null!;
    }
}