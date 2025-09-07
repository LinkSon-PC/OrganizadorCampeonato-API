using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Entrenadores.Consultas.ObtenerTodosEntrenadores
{
    public record ConsultaObtenerTodosEntrenadores : IRequest<List<ListadoEntrenadorDTO>>
    {
    }
}
