using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.PartidoEquipos.Consultas.ObtenerTodosPartidoEquipos
{
    public record ListadoPartidoEquipoDTO
    {
        public required Guid Id { get; init; }
        public required Guid PartidoId { get; init; }
        public required Guid EquipoId { get; init; }
        public bool EsLocal { get; init; }
        public bool EsGanador { get; init; }
        public DateTime FechaCreacion { get; init; }
    }
}
