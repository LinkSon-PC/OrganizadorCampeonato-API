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

        public Jugador(Guid id) : base(id) { }

        public Persona Persona { get; init; } = null!;
        public List<EquipoJugador> EquipoJugadores { get; init; } = new();
    }
}
