using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Jugadores.Comandos.AsignarJugado
{
    public class ComandoAsiganarJugador : IRequest
    {
        public required string Identificacion { get; set; }
    }
}
