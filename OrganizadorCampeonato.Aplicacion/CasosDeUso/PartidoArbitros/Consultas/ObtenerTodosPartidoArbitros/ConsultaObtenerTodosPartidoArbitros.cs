using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;
using System.Collections.Generic;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.PartidoArbitros.Consultas.ObtenerTodosPartidoArbitros
{
    public record ConsultaObtenerTodosPartidoArbitros : IRequest<List<ListadoPartidoArbitroDTO>>
    {
    }
}
