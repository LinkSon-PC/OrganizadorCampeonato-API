using OrganizadorCampeonato.Dominio.Entidades;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Jugadores.Consultas.ObtenerJugadorPorId
{
    public static class MapeadorJugadorPorId
    {
        public static JugadorPorIdDTO ADto(this Jugador entity) =>
            new JugadorPorIdDTO
            {
                Id = entity.Id,
                Identificacion = entity.Persona?.Identificacion ?? string.Empty,
                Nombres = entity.Persona?.Nombres ?? string.Empty,
                Apellidos = entity.Persona?.Apellidos ?? string.Empty,
                FechaNacimiento = entity.Persona?.FechaNacimiento ?? default,
                Telefono = entity.Persona?.Telefono,
                Genero = entity.Persona?.Genero ?? Dominio.Enum.TipoGenero.Masculino,
                FechaCreacion = entity.FechaCreacion,
                UltimaFechaModificacion = entity.UltimaFechaModificacion
            };
    }
}
