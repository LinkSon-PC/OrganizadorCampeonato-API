using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;
using System.Collections.Generic;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Torneos.Consultas.ObtenerTodosTorneos
{
    public record ConsultaObtenerTodosTorneos : IRequest<List<ListadoTorneoDTO>>
    {
    }
}
