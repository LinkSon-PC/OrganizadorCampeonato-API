using OrganizadorCampeonato.Dominio.Comunes;
using OrganizadorCampeonato.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Dominio.Entidades
{
    public class Categoria : EntidadAuditable<Guid>
    {
        public TipoCategoria Tipo { get; set; }
        public TipoGenero Genero { get; set; }
        public List<Torneo> Torneos { get; set; }
    }
}
