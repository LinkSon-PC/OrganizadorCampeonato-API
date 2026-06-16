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

        public Arbitro(Guid Id)
        {
            this.Id = Id;
        }

        public Persona? Persona { get; private set; }
        public List<PartidoArbitro> PartidoArbitros { get; private set; } = new();
    }
}
