using OrganizadorCampeonato.Dominio.Comunes;
using OrganizadorCampeonato.Dominio.Enum;
using OrganizadorCampeonato.Dominio.Excepciones;
using System;

namespace OrganizadorCampeonato.Dominio.Entidades
{
    public class PartidoEquipo : EntidadAuditable<Guid>
    {
        private PartidoEquipo() { }

        public PartidoEquipo(Guid id, Guid partidoId, Guid equipoId, bool esLocal) : base(id)
        {
            PartidoId = partidoId;
            EquipoId = equipoId;
            EsLocal = esLocal;
        }

        public Guid PartidoId { get; init; }
        public Guid EquipoId { get; init; }
        public bool EsLocal { get; init; }

        public Partido Partido { get; init; } = null!;
        public Equipo Equipo { get; init; } = null!;
    }
}