using OrganizadorCampeonato.Dominio.Comunes;
using OrganizadorCampeonato.Dominio.Enum;
using System;

namespace OrganizadorCampeonato.Dominio.Entidades
{
    public class ResultadoPeriodo : EntidadAuditable<Guid>
    {
        private ResultadoPeriodo() { }

        public ResultadoPeriodo(Guid partidoId, TipoPeriodo periodo, Guid equipoId)
        {
            PartidoId = partidoId;
            Periodo = periodo;
            EquipoId = equipoId;
        }

        public Guid PartidoId { get; private set; }
        public TipoPeriodo Periodo { get; private set; }
        public Guid EquipoId { get; private set; }

        public Partido Partido { get; private set; } = null!;
        public Equipo Equipo { get; private set; } = null!;
    }
}