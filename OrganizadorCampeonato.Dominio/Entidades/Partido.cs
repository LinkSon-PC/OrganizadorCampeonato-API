using OrganizadorCampeonato.Dominio.Comunes;
using OrganizadorCampeonato.Dominio.Enum;
using OrganizadorCampeonato.Dominio.Excepciones;
using System;
using System.Collections.Generic;

namespace OrganizadorCampeonato.Dominio.Entidades
{
    public class Partido : EntidadAuditable<Guid>
    {
        private Partido() { }

        public Partido(Guid id, DateTime fechaHora, string lugar, Guid torneoId, int ronda, string grupo = "") : base(id)
        {
            ValidarFechaHora(fechaHora);
            ValidarLugar(lugar);

            FechaHora = fechaHora;
            Lugar = lugar.Trim();
            TorneoId = torneoId;
            Ronda = ronda;
            Grupo = grupo.Trim();
            Estado = EstadoPartido.Programada;
        }

        public DateTime FechaHora { get; init; }
        public string Lugar { get; init; } = null!;
        public Guid TorneoId { get; init; }
        public int Ronda { get; init; }
        public string? Grupo { get; init; }
        public EstadoPartido Estado { get; init; }
        public decimal? PuntosLocal_P1 { get; init; }
        public decimal? PuntosVisitante_P1 { get; init; }
        public decimal? PuntosLocal_P2 { get; init; }
        public decimal? PuntosVisitante_P2 { get; init; }
        public decimal? PuntosLocal_P3 { get; init; }
        public decimal? PuntosVisitante_P3 { get; init; }
        public decimal? PuntosLocal_P4 { get; init; }
        public decimal? PuntosVisitante_P4 { get; init; }
        public decimal? PuntosLocal_Prorroga { get; init; }
        public decimal? PuntosVisitante_Prorroga { get; init; }
        public decimal? PuntosLocal_Prorroga2 { get; init; }
        public decimal? PuntosVisitante_Prorroga2 { get; init; }
        public decimal PuntosLocal => (PuntosLocal_P1 ?? 0) + (PuntosLocal_P2 ?? 0) + (PuntosLocal_P3 ?? 0) + (PuntosLocal_P4 ?? 0) + (PuntosLocal_Prorroga ?? 0) + (PuntosLocal_Prorroga2 ?? 0);
        public decimal PuntosVisitante => (PuntosVisitante_P1 ?? 0) + (PuntosVisitante_P2 ?? 0) + (PuntosVisitante_P3 ?? 0) + (PuntosVisitante_P4 ?? 0) + (PuntosVisitante_Prorroga ?? 0) + (PuntosVisitante_Prorroga2 ?? 0);

        public Guid? GanadorId { get; init; }
        public Equipo? Ganador { get; init; }

        public Torneo? Torneo { get; init; }
        public List<PartidoEquipo> PartidoEquipos { get; init; } = new();
        public List<PartidoArbitro> PartidoArbitros { get; init; } = new();
        public List<ResultadoPeriodo> ResultadosPeriodos { get; init; } = new();

        public void ValidarFechaHora(DateTime fechaHora)
        {
            if (fechaHora == default)
                throw new ExcepcionReglaDeNegocio("La fecha y hora del partido es requerida");
        }

        public void ValidarLugar(string lugar)
        {
            if (string.IsNullOrWhiteSpace(lugar))
                throw new ExcepcionReglaDeNegocio("El lugar es requerido");
        }

        public Guid? ObtenerGanadorPeriodo(TipoPeriodo periodo, Guid equipoLocalId, Guid equipoVisitanteId)
        {
            var (puntosLocal, puntosVisitante) = periodo switch
            {
                TipoPeriodo.P1 => (PuntosLocal_P1, PuntosVisitante_P1),
                TipoPeriodo.P2 => (PuntosLocal_P2, PuntosVisitante_P2),
                TipoPeriodo.P3 => (PuntosLocal_P3, PuntosVisitante_P3),
                TipoPeriodo.P4 => (PuntosLocal_P4, PuntosVisitante_P4),
                TipoPeriodo.Prorroga => (PuntosLocal_Prorroga, PuntosVisitante_Prorroga),
                TipoPeriodo.Prorroga2 => (PuntosLocal_Prorroga2, PuntosVisitante_Prorroga2),
                _ => (null, null)
            };

            if (!puntosLocal.HasValue || !puntosVisitante.HasValue)
                return null;

            if (puntosLocal > puntosVisitante)
                return equipoLocalId;
            else if (puntosVisitante > puntosLocal)
                return equipoVisitanteId;
            else
                return null;
        }
    }
}