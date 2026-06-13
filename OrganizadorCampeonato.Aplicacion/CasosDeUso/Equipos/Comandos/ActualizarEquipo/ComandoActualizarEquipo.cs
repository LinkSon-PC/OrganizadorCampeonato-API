using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Equipos.Comandos.ActualizarEquipo
{
    public record ComandoActualizarEquipo : IRequest
    {
        public required Guid Id { get; set; }
        public required string Nombre { get; init; }
        public Guid? EntrenadorId { get; init; }
        public Guid? CategoriaId { get; init; }
    }
}
