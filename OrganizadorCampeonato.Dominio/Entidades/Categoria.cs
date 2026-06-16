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
        private Categoria() { }
        public Categoria(TipoCategoria categoria, TipoGenero genero)
        {
            Tipo = categoria;
            Genero = genero;
        }

        public TipoCategoria Tipo { get; private set; }
        public TipoGenero Genero { get; private set; }
        public List<Torneo> Torneos { get; private set; } = new();
        public List<Equipo> Equipos { get; private set; } = new();
    }
}
