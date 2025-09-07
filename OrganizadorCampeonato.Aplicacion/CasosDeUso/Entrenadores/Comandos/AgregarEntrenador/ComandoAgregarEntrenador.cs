using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Entrenadores.Comandos.AgregarEntrenador
{
    public record ComandoAgregarEntrenador (
        string Identificacion, 
        string Nombres, 
        string Apellidos, 
        DateTime FechaNacimiento, 
        string? Telefono, 
        TipoGenero Genero
    ) : IRequest<Guid>;
}
