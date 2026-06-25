using OrganizadorCampeonato.Dominio.Entidades;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Entrenadores.Consultas.ObtenerEntrenadorPorId
{
    public static class MapeadorEntrenadorPorId
    {
        public static EntrenadorDTO ADto(this Entrenador entity) =>
            new EntrenadorDTO
            {
                Id = entity.Id,
                Identificacion = entity.Persona?.Identificacion ?? string.Empty,
                Nombres = entity.Persona?.Nombres ?? string.Empty,
                Apellidos = entity.Persona?.Apellidos ?? string.Empty,
                Genero = entity.Persona?.Genero ?? Dominio.Enum.TipoGenero.Masculino,
                FechaNacimiento = entity.Persona?.FechaNacimiento ?? default,
                Telefono = entity.Persona?.Telefono,
                FechaCreacion = entity.FechaCreacion,
                UltimaFechaModificacion = entity.UltimaFechaModificacion
            };
    }
}
