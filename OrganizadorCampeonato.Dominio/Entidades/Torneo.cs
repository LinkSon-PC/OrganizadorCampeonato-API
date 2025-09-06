using OrganizadorCampeonato.Dominio.Comunes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Dominio.Entidades
{
    public class Torneo : EntidadAuditable<Guid>
    {
        public string Nombre { get; private set; }
        public Guid? CategoriaId { get; private set; }
        public Categoria? Categoria { get; private set; }
        public List<TorneoEquipo> TorneoEquipo { get; private set; }
    }
}
