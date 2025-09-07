using OrganizadorCampeonato.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Personas.Consultas.ObtenerTodos
{
    public class ListadoPersonasDTO
    {
        public Guid Id { get; set; }
        public required string Identificacion { get; set; }
        public required string Nombres { get; set; }
        public required string Apellidos { get; set; }
        public DateTime FechaNaciemiento { get; set; }
        public TipoGenero Genero { get; set; }
        public string? Telefono { get; set; }
    }
}
