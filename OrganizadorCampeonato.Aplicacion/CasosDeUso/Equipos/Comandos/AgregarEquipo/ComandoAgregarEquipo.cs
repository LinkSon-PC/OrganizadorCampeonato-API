using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Equipos.Comandos.AgregarEquipo
{
    public record ComandoAgregarEquipo : IRequest<Guid>
    {
        public required string Nombre { get; init; }
        public Guid? EntrenadorId { get; init; }
    }
}
