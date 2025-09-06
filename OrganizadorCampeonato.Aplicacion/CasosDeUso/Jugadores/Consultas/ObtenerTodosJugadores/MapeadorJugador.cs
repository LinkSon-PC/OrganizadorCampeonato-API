using OrganizadorCampeonato.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Jugadores.Consultas.ObtenerTodosJugadores
{
    public static class MapeadorJugador
    {
        public static JugadorDTO ADto(this Jugador jugador) => new JugadorDTO
        {
            Id = jugador.Id,
            Identificacion = jugador.Persona?.Identificacion!,
            Nombres = jugador.Persona?.Nombres!,
            Apellidos = jugador.Persona?.Apellidos!,
            FechaNaciemiento = jugador.Persona!.FechaNacimiento,
            Telefono = jugador.Persona.Telefono
        };
    }
}
