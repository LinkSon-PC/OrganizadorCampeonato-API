using OrganizadorCampeonato.Dominio.Comunes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Dominio.Entidades
{
    public class Equipo : EntidadAuditable<Guid>
    {
        public string Nombre { get; private set; }
        public Guid EntrenadorId { get; private set; }
        public Entrenador Entrenador { get; private set; }
    }
}
