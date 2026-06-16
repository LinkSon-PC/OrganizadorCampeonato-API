using OrganizadorCampeonato.Dominio.Comunes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Dominio.Entidades
{
    public class Entrenador : EntidadAuditable<Guid>
    {
        private Entrenador() { }
        public Entrenador(Guid id) : base(id) { }

        public Persona Persona { get; init; } = null!;
        public List<Equipo> Equipos { get; init; } = new();
    }
}
