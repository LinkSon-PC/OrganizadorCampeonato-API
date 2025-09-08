using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Equipos.Consultas.ObtenerTodosEquipos
{
    public record ListadoEquiposDTO
    {
        public required Guid Id { get; init; }
        public required string Nombre { get; init; }
        public Guid? EntrenadorId { get; init; }
        public string? Nombres { get; init; }
        public string? Apellidos { get; init; }
    }
}
