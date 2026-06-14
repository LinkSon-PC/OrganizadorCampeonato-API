using OrganizadorCampeonato.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Personas.Consultas.ObtenerPorId
{
    public record PersonaDTO
    {
        public Guid Id { get; init; }
        public required string Identificacion { get; init; }
        public required string Nombres { get; init; }
        public required string Apellidos { get; init; }
        public required string Genero { get; init; }
        public DateTime FechaNaciemiento { get; init; }
        public string? Telefono { get; init; }
    }
}
