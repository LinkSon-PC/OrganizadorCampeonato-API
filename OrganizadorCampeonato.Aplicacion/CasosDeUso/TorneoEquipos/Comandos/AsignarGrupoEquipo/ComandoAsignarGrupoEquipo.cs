using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.TorneoEquipos.Comandos.AsignarGrupoEquipo
{
    public record ComandoAsignarGrupoEquipo : IRequest
    {
        public required Guid Id { get; init; }
        public required string Grupo { get; init; }
        public int? PosicionGrupo { get; init; }
    }
}
