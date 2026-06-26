using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;
using System.Collections.Generic;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.OficialesPartido.Consultas.ObtenerTodosOficialesPartido
{
    public record ConsultaObtenerTodosOficialesPartido : IRequest<List<ListadoOficialPartidoDTO>>
    {
    }
}
