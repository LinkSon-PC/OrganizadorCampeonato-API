using OrganizadorCampeonato.Dominio.Comunes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Dominio.Entidades
{
    public class Jugador : EntidadAuditable<Guid>
    {
        private Jugador() { }

        public Jugador(Guid Id)
        {
            this.Id = Id;
        }

        public Persona Persona { get; private set; } = null!;
        public List<EquipoJugador> EquipoJugadores { get; private set; } = new();
    }
}
