using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;
using System.Collections.Generic;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.PartidoEquipos.Consultas.ObtenerTodosPartidoEquipos
{
    public record ConsultaObtenerTodosPartidoEquipos : IRequest<List<ListadoPartidoEquipoDTO>>
    {
    }
}
