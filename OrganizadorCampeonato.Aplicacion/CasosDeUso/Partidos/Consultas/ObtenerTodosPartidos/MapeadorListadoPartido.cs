using OrganizadorCampeonato.Dominio.Entidades;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Partidos.Consultas.ObtenerTodosPartidos
{
    public static class MapeadorListadoPartido
    {
        public static ListadoPartidoDTO ADto(this Partido entity) =>
            new ListadoPartidoDTO
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
                GanadorId = entity.GanadorId,
                FechaCreacion = entity.FechaCreacion
            };
    }
}
