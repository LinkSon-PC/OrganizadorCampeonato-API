using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Jugadores.Consultas.ObtenerTodosJugadores
{
    public class JugadorDTO
    {
        public Guid Id { get; set; }
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNaciemiento { get; set; }
        public string Telefono { get; set; }
    }
}
