using OrganizadorCampeonato.Dominio.Entidades;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Partidos.Consultas.ObtenerPartidoPorId
{
    public static class MapeadorPartidoPorId
    {
        public static PartidoDTO ADto(this Partido entity) =>
            new PartidoDTO
            {
                Id = entity.Id,
                FechaHora = entity.FechaHora,
                Lugar = entity.Lugar,
                TorneoId = entity.TorneoId,
                Ronda = entity.Ronda,
                Grupo = entity.Grupo,
                Estado = entity.Estado,
                PuntosLocal = entity.PuntosLocal,
                PuntosVisitante = entity.PuntosVisitante,
                FechaCreacion = entity.FechaCreacion,
                UltimaFechaModificacion = entity.UltimaFechaModificacion
            };
    }
}
