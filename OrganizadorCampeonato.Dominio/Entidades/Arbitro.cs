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
        public Persona? Persona { get; private set; }
    }
}
