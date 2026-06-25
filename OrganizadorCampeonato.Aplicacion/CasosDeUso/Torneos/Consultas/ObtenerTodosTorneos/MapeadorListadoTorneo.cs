using OrganizadorCampeonato.Dominio.Entidades;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Torneos.Consultas.ObtenerTodosTorneos
{
    public static class MapeadorListadoTorneo
    {
        public static ListadoTorneoDTO ADto(this Torneo entity) =>
            new ListadoTorneoDTO
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                Lugar = entity.Lugar,
                CategoriaId = entity.CategoriaId,
                Formato = entity.Formato,
                FechaInicio = entity.FechaInicio,
                FechaFin = entity.FechaFin,
                FechaCreacion = entity.FechaCreacion
            };
    }
}
