using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Equipos.Consultas.ObtenerTodosEquipos
{
    public record ConsultaObtenerTodosEquipos : IRequest<List<ListadoEquiposDTO>>
    {
    }
}
