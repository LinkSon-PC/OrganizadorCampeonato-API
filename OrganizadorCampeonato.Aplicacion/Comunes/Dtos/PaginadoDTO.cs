using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.Comunes.Dtos
{
    public record PaginadoDTO<T>
    {
        public List<T> Elementos { get; set; } = [];
        public int Total { get; set; }
    }
}
