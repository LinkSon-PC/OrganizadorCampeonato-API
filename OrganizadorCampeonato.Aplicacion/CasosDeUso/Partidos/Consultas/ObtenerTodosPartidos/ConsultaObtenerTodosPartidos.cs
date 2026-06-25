using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;
using System.Collections.Generic;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Partidos.Consultas.ObtenerTodosPartidos
{
    public record ConsultaObtenerTodosPartidos : IRequest<List<ListadoPartidoDTO>>
    {
    }
}
