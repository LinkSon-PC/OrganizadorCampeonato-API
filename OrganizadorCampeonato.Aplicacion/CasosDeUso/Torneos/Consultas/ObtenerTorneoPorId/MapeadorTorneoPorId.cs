using OrganizadorCampeonato.Dominio.Entidades;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Torneos.Consultas.ObtenerTorneoPorId
{
    public static class MapeadorTorneoPorId
    {
        public static TorneoPorIdDTO ADto(this Torneo entity) =>
            new TorneoPorIdDTO
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                Lugar = entity.Lugar,
                Descripcion = entity.Descripcion,
                CategoriaId = entity.CategoriaId,
                Formato = entity.Formato,
                Estado = entity.Estado,
                FechaInicio = entity.FechaInicio,
                FechaFin = entity.FechaFin,
                FechaCreacion = entity.FechaCreacion,
                UltimaFechaModificacion = entity.UltimaFechaModificacion
            };
    }
}
