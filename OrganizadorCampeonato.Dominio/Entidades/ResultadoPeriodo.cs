using OrganizadorCampeonato.Dominio.Comunes;
using OrganizadorCampeonato.Dominio.Enum;
using System;

namespace OrganizadorCampeonato.Dominio.Entidades
{
    public class ResultadoPeriodo : EntidadAuditable<Guid>
    {
        private ResultadoPeriodo() { }

        public ResultadoPeriodo(Guid id, Guid partidoId, TipoPeriodo periodo, int numeroProrroga, int puntosLocal, int puntosVisitante) : base(id)
        {
            PartidoId = partidoId;
            Periodo = periodo;
            NumeroProrroga = numeroProrroga;
            PuntosLocal = puntosLocal;
            PuntosVisitante = puntosVisitante;
        }

        public Guid PartidoId { get; init; }
        public TipoPeriodo Periodo { get; init; }
        public int NumeroProrroga { get; init; }
        public int PuntosLocal { get; init; }
        public int PuntosVisitante { get; init; }

        public Partido Partido { get; init; } = null!;
    }
}