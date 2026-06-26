using OrganizadorCampeonato.Dominio.Enum;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.OficialesPartido.Consultas.ObtenerTodosOficialesPartido
{
    public record ListadoOficialPartidoDTO
    {
        public required Guid Id { get; init; }
        public required Guid PartidoId { get; init; }
        public required Guid ArbitroId { get; init; }
        public required TipoOficial Rol { get; init; }
        public DateTime FechaCreacion { get; init; }
    }
}
