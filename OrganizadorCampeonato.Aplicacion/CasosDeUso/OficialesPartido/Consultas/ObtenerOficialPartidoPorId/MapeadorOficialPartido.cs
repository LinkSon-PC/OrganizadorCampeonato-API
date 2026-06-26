using OrganizadorCampeonato.Dominio.Entidades;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.OficialesPartido.Consultas.ObtenerOficialPartidoPorId
{
    public static class MapeadorOficialPartido
    {
        public static OficialPartidoDTO ADto(this OficialPartido entity) =>
            new OficialPartidoDTO
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
