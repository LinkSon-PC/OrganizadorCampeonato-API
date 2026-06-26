using OrganizadorCampeonato.Dominio.Entidades;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.TorneoEquipos.Consultas.ObtenerTorneoEquipoPorId
{
    public static class MapeadorTorneoEquipoPorId
    {
        public static TorneoEquipoPorIdDTO ADto(this TorneoEquipo entity) =>
            new TorneoEquipoPorIdDTO
            {
                Id = entity.Id,
                TorneoId = entity.TorneoId,
                EquipoId = entity.EquipoId,
                NombreEquipo = entity.Equipo?.Nombre ?? string.Empty,
                FechaInscripcion = entity.FechaInscripcion,
                Estado = entity.Estado,
                Posicion = entity.Posicion,
                Grupo = entity.Grupo,
                PosicionGrupo = entity.PosicionGrupo,
                FechaCreacion = entity.FechaCreacion,
                UltimaFechaModificacion = entity.UltimaFechaModificacion
            };
    }
}
