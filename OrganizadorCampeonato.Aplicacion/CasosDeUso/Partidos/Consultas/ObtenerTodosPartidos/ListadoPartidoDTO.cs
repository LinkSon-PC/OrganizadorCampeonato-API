using OrganizadorCampeonato.Dominio.Enum;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Partidos.Consultas.ObtenerTodosPartidos
{
    public record ListadoPartidoDTO
    {
        public required Guid Id { get; init; }
        public DateTime FechaHora { get; init; }
        public required string Lugar { get; init; }
        public required Guid TorneoId { get; init; }
        public FasePartido Fase { get; init; }
        public int Jornada { get; init; }
        public string? Grupo { get; init; }
        public int? NumeroRondaKO { get; init; }
        public EstadoPartido Estado { get; init; }
        public int PuntosLocal { get; init; }
        public int PuntosVisitante { get; init; }
        public DateTime FechaCreacion { get; init; }
    }
}
