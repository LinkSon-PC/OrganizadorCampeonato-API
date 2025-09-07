using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Entrenadores.Comandos.AsignarEntrenador
{
    public record ComandoAsignarEntrenador (string Identificacion) : IRequest;
}
