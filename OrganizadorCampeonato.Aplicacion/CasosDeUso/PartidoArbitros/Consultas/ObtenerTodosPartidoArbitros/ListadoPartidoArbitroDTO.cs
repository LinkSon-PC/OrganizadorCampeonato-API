using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.PartidoArbitros.Consultas.ObtenerTodosPartidoArbitros
{
    public record ListadoPartidoArbitroDTO
    {
        public required Guid Id { get; init; }
        public required Guid PartidoId { get; init; }
        public required Guid ArbitroId { get; init; }
        public string? Rol { get; init; }
        public DateTime FechaCreacion { get; init; }
    }
}
