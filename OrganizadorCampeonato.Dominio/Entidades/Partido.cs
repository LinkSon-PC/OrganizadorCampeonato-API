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

        public Partido(Guid id, DateTime fechaHora, string lugar, Guid torneoId, FasePartido fase, int jornada, string grupo = "", int? numeroRondaKO = null, Guid? partidoOrigenLocalId = null, Guid? partidoOrigenVisitanteId = null) : base(id)
        {
            ValidarFechaHora(fechaHora);
            ValidarLugar(lugar);

            FechaHora = fechaHora;
            Lugar = lugar.Trim();
            TorneoId = torneoId;
            Fase = fase;
            Jornada = jornada;
            Grupo = grupo.Trim();
            NumeroRondaKO = numeroRondaKO;
            PartidoOrigenLocalId = partidoOrigenLocalId;
            PartidoOrigenVisitanteId = partidoOrigenVisitanteId;
            Estado = EstadoPartido.Programada;
        }

        public DateTime FechaHora { get; init; }
        public string Lugar { get; init; } = null!;
        public Guid TorneoId { get; init; }
        public FasePartido Fase { get; init; }
        public int Jornada { get; init; }
        public string? Grupo { get; init; }
        public int? NumeroRondaKO { get; init; }
        public EstadoPartido Estado { get; init; }

        public Guid? PartidoOrigenLocalId { get; init; }
        public Guid? PartidoOrigenVisitanteId { get; init; }
        public Partido? PartidoOrigenLocal { get; init; }
        public Partido? PartidoOrigenVisitante { get; init; }

        [NotMapped]
        public int PuntosLocal => ResultadosPeriodos?.Sum(r => r.PuntosLocal) ?? 0;

        [NotMapped]
        public int PuntosVisitante => ResultadosPeriodos?.Sum(r => r.PuntosVisitante) ?? 0;

        public Torneo? Torneo { get; init; }
        public List<PartidoEquipo> PartidoEquipos { get; init; } = new();
        public List<OficialPartido> OficialesPartido { get; init; } = new();
        public List<ResultadoPeriodo> ResultadosPeriodos { get; init; } = new();
        public List<JugadorPartido> JugadoresPartido { get; init; } = new();
        public List<Falta> Faltas { get; init; } = new();
        public List<TiempoMuerto> TiemposMuertos { get; init; } = new();

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