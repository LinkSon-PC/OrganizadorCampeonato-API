using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Jugadores.Comandos.AgregarJugador
{
    public class ComandoAgregarJugador : IRequest<Guid>
    {
        public required string Identificacion { get; set; }
        public required string Nombres { get; set; }
        public required string Apellidos { get; set; }
        public DateTime FechaNaciemiento { get; set; }
        public string? Telefono { get; set; }
    }
}
