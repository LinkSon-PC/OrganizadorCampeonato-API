using OrganizadorCampeonato.Dominio.Enum;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Torneos.Consultas.ObtenerTorneoPorId
{
    public record TorneoPorIdDTO
    {
        public required Guid Id { get; init; }
        public required string Nombre { get; init; }
        public required string Lugar { get; init; }
        public string? Descripcion { get; init; }
        public required Guid CategoriaId { get; init; }
        public FormatoTorneo Formato { get; init; }
        public DateTime FechaInicio { get; init; }
        public DateTime FechaFin { get; init; }
        public DateTime FechaCreacion { get; init; }
        public DateTime? UltimaFechaModificacion { get; init; }
    }
}
