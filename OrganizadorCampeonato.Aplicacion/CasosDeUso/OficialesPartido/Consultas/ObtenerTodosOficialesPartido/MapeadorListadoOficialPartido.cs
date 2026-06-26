using OrganizadorCampeonato.Dominio.Entidades;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.OficialesPartido.Consultas.ObtenerTodosOficialesPartido
{
    public static class MapeadorListadoOficialPartido
    {
        public static ListadoOficialPartidoDTO ADto(this OficialPartido entity) =>
            new ListadoOficialPartidoDTO
            {
                Id = entity.Id,
                PartidoId = entity.PartidoId,
                ArbitroId = entity.ArbitroId,
                Rol = entity.Rol,
                FechaCreacion = entity.FechaCreacion
            };
    }
}
