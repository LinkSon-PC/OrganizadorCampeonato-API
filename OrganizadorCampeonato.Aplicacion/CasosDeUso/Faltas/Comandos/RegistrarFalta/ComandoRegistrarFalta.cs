using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Dominio.Enum;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Faltas.Comandos.RegistrarFalta
{
    public record ComandoRegistrarFalta : IRequest<Guid>
    {
        public required Guid JugadorPartidoId { get; init; }
        public required TipoFalta Tipo { get; init; }
        public required TipoPeriodo Periodo { get; init; }
        public required int Minuto { get; init; }
        public required int NumeroFalta { get; init; }
    }
}
