using OrganizadorCampeonato.Dominio.Comunes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Dominio.Entidades
{
    public class Arbitro : EntidadAuditable<Guid>
    {
        private Arbitro() { }

        public Arbitro(Guid id) : base(id) { }

        public Persona? Persona { get; init; }
        public List<OficialPartido> OficialesPartido { get; init; } = new();
    }
}
