using OrganizadorCampeonato.Dominio.Entidades;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.EquipoJugadores.Consultas.ObtenerJugadoresPorEquipo
{
    public static class MapeadorJugadorEquipo
    {
        public static JugadorEquipoDTO ADto(this EquipoJugador equipoJugador) =>
            new JugadorEquipoDTO
            {
                InscripcionId = equipoJugador.Id,
                JugadorId = equipoJugador.JugadorId,
                EstaActivo = equipoJugador.EstaActivo,
                Nombres = equipoJugador.Jugador.Persona.Nombres,
                Apellidos = equipoJugador.Jugador.Persona.Apellidos,
                Genero = equipoJugador.Jugador.Persona.Genero
            };
    }
}
