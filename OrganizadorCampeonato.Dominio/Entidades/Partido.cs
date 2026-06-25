using OrganizadorCampeonato.Dominio.Comunes;
using OrganizadorCampeonato.Dominio.Enum;
using OrganizadorCampeonato.Dominio.Excepciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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

        [NotMapped]
        public int PuntosLocal => ResultadosPeriodos?.Sum(r => r.PuntosLocal) ?? 0;

        [NotMapped]
        public int PuntosVisitante => ResultadosPeriodos?.Sum(r => r.PuntosVisitante) ?? 0;

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
    }
}