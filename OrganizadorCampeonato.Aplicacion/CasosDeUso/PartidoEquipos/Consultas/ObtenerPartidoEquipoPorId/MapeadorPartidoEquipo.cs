using OrganizadorCampeonato.Dominio.Entidades;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.PartidoEquipos.Consultas.ObtenerPartidoEquipoPorId
{
    public static class MapeadorPartidoEquipo
    {
        public static PartidoEquipoDTO ADto(this PartidoEquipo entity) =>
            new PartidoEquipoDTO
            {
                Id = entity.Id,
                PartidoId = entity.PartidoId,
                EquipoId = entity.EquipoId,
                EsLocal = entity.EsLocal,
                FechaCreacion = entity.FechaCreacion,
                UltimaFechaModificacion = entity.UltimaFechaModificacion
            };
    }
}
