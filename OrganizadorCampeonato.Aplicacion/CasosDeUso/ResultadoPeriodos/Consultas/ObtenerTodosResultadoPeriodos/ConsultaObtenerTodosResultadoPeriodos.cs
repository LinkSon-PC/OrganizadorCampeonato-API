using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;
using System.Collections.Generic;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.ResultadoPeriodos.Consultas.ObtenerTodosResultadoPeriodos
{
    public record ConsultaObtenerTodosResultadoPeriodos : IRequest<List<ListadoResultadoPeriodoDTO>>
    {
    }
}
