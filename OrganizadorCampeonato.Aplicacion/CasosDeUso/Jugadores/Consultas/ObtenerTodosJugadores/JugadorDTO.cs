using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Jugadores.Consultas.ObtenerTodosJugadores
{
    public record JugadorDTO
    {
        public Guid Id { get; init; }
        public string Identificacion { get; init; }
        public string Nombres { get; init; }
        public string Apellidos { get; init; }
        public DateTime FechaNaciemiento { get; init; }
        public string Telefono { get; init; }
    }
}
