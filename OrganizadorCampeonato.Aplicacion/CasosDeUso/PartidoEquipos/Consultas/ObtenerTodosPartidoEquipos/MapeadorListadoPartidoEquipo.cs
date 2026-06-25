using OrganizadorCampeonato.Dominio.Entidades;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.PartidoEquipos.Consultas.ObtenerTodosPartidoEquipos
{
    public static class MapeadorListadoPartidoEquipo
    {
        public static ListadoPartidoEquipoDTO ADto(this PartidoEquipo entity) =>
            new ListadoPartidoEquipoDTO
            {
                Id = entity.Id,
                PartidoId = entity.PartidoId,
                EquipoId = entity.EquipoId,
                EsLocal = entity.EsLocal,
                FechaCreacion = entity.FechaCreacion
            };
    }
}
