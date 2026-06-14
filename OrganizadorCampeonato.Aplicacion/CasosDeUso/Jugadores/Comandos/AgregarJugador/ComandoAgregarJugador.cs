using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Jugadores.Comandos.AgregarJugador
{
    public record ComandoAgregarJugador : IRequest<Guid>
    {
        public required string Identificacion { get; init; }
        public required string Nombres { get; init; }
        public required string Apellidos { get; init; }
        public DateTime FechaNaciemiento { get; init; }
        public string? Telefono { get; init; }
        public required TipoGenero Genero { get; init; }
    }
}
