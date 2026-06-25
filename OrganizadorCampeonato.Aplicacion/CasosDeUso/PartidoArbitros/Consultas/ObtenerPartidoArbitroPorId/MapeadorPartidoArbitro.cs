using OrganizadorCampeonato.Dominio.Entidades;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.PartidoArbitros.Consultas.ObtenerPartidoArbitroPorId
{
    public static class MapeadorPartidoArbitro
    {
        public static PartidoArbitroDTO ADto(this PartidoArbitro entity) =>
            new PartidoArbitroDTO
            {
                Id = entity.Id,
                PartidoId = entity.PartidoId,
                ArbitroId = entity.ArbitroId,
                Rol = entity.Rol,
                FechaCreacion = entity.FechaCreacion,
                UltimaFechaModificacion = entity.UltimaFechaModificacion
            };
    }
}
