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
        public Categoria(Guid id, TipoCategoria categoria, TipoGenero genero) : base(id)
        {
            Tipo = categoria;
            Genero = genero;
        }

        public TipoCategoria Tipo { get; init; }
        public TipoGenero Genero { get; init; }
        public List<Torneo> Torneos { get; init; } = new();
        public List<Equipo> Equipos { get; init; } = new();
    }
}
