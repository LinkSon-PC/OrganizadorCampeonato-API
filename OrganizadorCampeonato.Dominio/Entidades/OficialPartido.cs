using OrganizadorCampeonato.Dominio.Comunes;
using OrganizadorCampeonato.Dominio.Enum;
using System;

namespace OrganizadorCampeonato.Dominio.Entidades
{
    public class OficialPartido : EntidadAuditable<Guid>
    {
        private OficialPartido() { }

        public OficialPartido(Guid id, Guid partidoId, Guid arbitroId, TipoOficial rol) : base(id)
        {
            PartidoId = partidoId;
            ArbitroId = arbitroId;
            Rol = rol;
        }

        public Guid PartidoId { get; init; }
        public Guid ArbitroId { get; init; }
        public TipoOficial Rol { get; init; }

        public Partido Partido { get; init; } = null!;
        public Arbitro Arbitro { get; init; } = null!;
    }
}
