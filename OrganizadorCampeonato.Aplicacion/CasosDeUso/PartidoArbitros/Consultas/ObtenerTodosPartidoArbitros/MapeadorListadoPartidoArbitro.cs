using OrganizadorCampeonato.Dominio.Entidades;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.PartidoArbitros.Consultas.ObtenerTodosPartidoArbitros
{
    public static class MapeadorListadoPartidoArbitro
    {
        public static ListadoPartidoArbitroDTO ADto(this PartidoArbitro entity) =>
            new ListadoPartidoArbitroDTO
            {
                Id = entity.Id,
                PartidoId = entity.PartidoId,
                ArbitroId = entity.ArbitroId,
                Rol = entity.Rol,
                FechaCreacion = entity.FechaCreacion
            };
    }
}
