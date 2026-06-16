using OrganizadorCampeonato.Dominio.Comunes;
using System;

namespace OrganizadorCampeonato.Dominio.Entidades
{
    public class PartidoArbitro : EntidadAuditable<Guid>
    {
        private PartidoArbitro() { }

        public PartidoArbitro(Guid partidoId, Guid arbitroId, string? rol)
        {
            PartidoId = partidoId;
            ArbitroId = arbitroId;
            Rol = rol;
        }

        public Guid PartidoId { get; private set; }
        public Guid ArbitroId { get; private set; }
        public string? Rol { get; private set; }

        public Partido Partido { get; private set; } = null!;
        public Arbitro Arbitro { get; private set; } = null!;
    }
}