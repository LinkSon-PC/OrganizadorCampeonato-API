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

        public Partido(DateTime fechaHora, string lugar, Guid torneoId, int ronda, string grupo = "")
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

        public DateTime FechaHora { get; private set; }
        public string Lugar { get; private set; } = null!;
        public Guid TorneoId { get; private set; }
        public int Ronda { get; private set; }
        public string? Grupo { get; private set; }
        public EstadoPartido Estado { get; private set; }
        public decimal? PuntosLocal_P1 { get; private set; }
        public decimal? PuntosVisitante_P1 { get; private set; }
        public decimal? PuntosLocal_P2 { get; private set; }
        public decimal? PuntosVisitante_P2 { get; private set; }
        public decimal? PuntosLocal_P3 { get; private set; }
        public decimal? PuntosVisitante_P3 { get; private set; }
        public decimal? PuntosLocal_P4 { get; private set; }
        public decimal? PuntosVisitante_P4 { get; private set; }
        public decimal? PuntosLocal_Prorroga { get; private set; }
        public decimal? PuntosVisitante_Prorroga { get; private set; }
        public decimal PuntosLocal => (PuntosLocal_P1 ?? 0) + (PuntosLocal_P2 ?? 0) + (PuntosLocal_P3 ?? 0) + (PuntosLocal_P4 ?? 0) + (PuntosLocal_Prorroga ?? 0);
        public decimal PuntosVisitante => (PuntosVisitante_P1 ?? 0) + (PuntosVisitante_P2 ?? 0) + (PuntosVisitante_P3 ?? 0) + (PuntosVisitante_P4 ?? 0) + (PuntosVisitante_Prorroga ?? 0);

        public Guid? GanadorId { get; private set; }
        public Equipo? Ganador { get; private set; }

        public Torneo? Torneo { get; private set; }
        public List<PartidoEquipo> PartidoEquipos { get; private set; } = new();
        public List<PartidoArbitro> PartidoArbitros { get; private set; } = new();

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

        public void ActualizarPuntuacion(
            decimal? puntosLocal_P1, decimal? puntosVisitante_P1,
            decimal? puntosLocal_P2, decimal? puntosVisitante_P2,
            decimal? puntosLocal_P3, decimal? puntosVisitante_P3,
            decimal? puntosLocal_P4, decimal? puntosVisitante_P4,
            decimal? puntosLocal_Prorroga, decimal? puntosVisitante_Prorroga)
        {
            PuntosLocal_P1 = puntosLocal_P1;
            PuntosVisitante_P1 = puntosVisitante_P1;
            PuntosLocal_P2 = puntosLocal_P2;
            PuntosVisitante_P2 = puntosVisitante_P2;
            PuntosLocal_P3 = puntosLocal_P3;
            PuntosVisitante_P3 = puntosVisitante_P3;
            PuntosLocal_P4 = puntosLocal_P4;
            PuntosVisitante_P4 = puntosVisitante_P4;
            PuntosLocal_Prorroga = puntosLocal_Prorroga;
            PuntosVisitante_Prorroga = puntosVisitante_Prorroga;
        }

        public void MarcarComoCompletado(Guid? ganadorId)
        {
            if (ganadorId == Guid.Empty)
                throw new ExcepcionReglaDeNegocio("Debe especificar el equipo ganador");
            GanadorId = ganadorId;
            Estado = EstadoPartido.Completada;
        }

        public void MarcarComoCancelada()
        {
            Estado = EstadoPartido.Cancelada;
        }
    }
}