using OrganizadorCampeonato.Dominio.Comunes;
using OrganizadorCampeonato.Dominio.Enum;
using System;

namespace OrganizadorCampeonato.Dominio.Entidades
{
    public class ResultadoPeriodo : EntidadAuditable<Guid>
    {
        private ResultadoPeriodo() { }

        public ResultadoPeriodo(Guid id, Guid partidoId, TipoPeriodo periodo, Guid equipoId) : base(id)
        {
            PartidoId = partidoId;
            Periodo = periodo;
            EquipoId = equipoId;
        }

        public Guid PartidoId { get; init; }
        public TipoPeriodo Periodo { get; init; }
        public Guid EquipoId { get; init; }

        public Partido Partido { get; init; } = null!;
        public Equipo Equipo { get; init; } = null!;
    }
}