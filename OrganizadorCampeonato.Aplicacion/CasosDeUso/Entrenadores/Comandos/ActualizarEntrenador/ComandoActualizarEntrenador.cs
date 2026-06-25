using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Dominio.Enum;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Entrenadores.Comandos.ActualizarEntrenador
{
    public record ComandoActualizarEntrenador : IRequest
    {
        public required Guid Id { get; init; }
        public required string Identificacion { get; init; }
        public required string Nombres { get; init; }
        public required string Apellidos { get; init; }
        public required DateTime FechaNacimiento { get; init; }
        public string? Telefono { get; init; }
        public required TipoGenero Genero { get; init; }
    }
}
