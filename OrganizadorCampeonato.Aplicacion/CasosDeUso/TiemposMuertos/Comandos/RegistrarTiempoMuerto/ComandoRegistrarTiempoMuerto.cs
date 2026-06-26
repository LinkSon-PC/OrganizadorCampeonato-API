using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Dominio.Enum;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.TiemposMuertos.Comandos.RegistrarTiempoMuerto
{
    public record ComandoRegistrarTiempoMuerto : IRequest<Guid>
    {
        public required Guid PartidoId { get; init; }
        public required Guid EquipoId { get; init; }
        public required TipoPeriodo Periodo { get; init; }
        public required int Minuto { get; init; }
        public required int NumeroTimeout { get; init; }
        public required bool EsPrimeraMitad { get; init; }
    }
}
