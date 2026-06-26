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
                Fase = entity.Fase,
                Jornada = entity.Jornada,
                Grupo = entity.Grupo,
                NumeroRondaKO = entity.NumeroRondaKO,
                Estado = entity.Estado,
                PartidoOrigenLocalId = entity.PartidoOrigenLocalId,
                PartidoOrigenVisitanteId = entity.PartidoOrigenVisitanteId,
                PuntosLocal = entity.PuntosLocal,
                PuntosVisitante = entity.PuntosVisitante,
                FechaCreacion = entity.FechaCreacion,
                UltimaFechaModificacion = entity.UltimaFechaModificacion
            };
    }
}
