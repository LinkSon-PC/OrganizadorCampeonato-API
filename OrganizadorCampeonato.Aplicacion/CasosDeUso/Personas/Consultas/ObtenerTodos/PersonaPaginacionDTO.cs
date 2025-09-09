using OrganizadorCampeonato.Aplicacion.Comunes.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Personas.Consultas.ObtenerTodos
{
    public record PersonaPaginacionDTO : PaginacionDTO
    {
        public string? Identificacion { get; init; }
        public string? Nombres { get; init; }
        public string? Apellidos { get; init; }
        public string? Telefono { get; init; }
        public bool? EsJugador { get; init; } = false;
        public bool? EsEntrenador { get; init; } = false;
        public bool? EsArbitro { get; init; } = false;
    }
}
