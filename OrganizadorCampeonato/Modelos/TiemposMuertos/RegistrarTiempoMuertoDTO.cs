using OrganizadorCampeonato.Dominio.Enum;

namespace OrganizadorCampeonato.Modelos.TiemposMuertos
{
    public record RegistrarTiempoMuertoDTO
    {
        public required Guid PartidoId { get; init; }
        public required Guid EquipoId { get; init; }
        public required TipoPeriodo Periodo { get; init; }
        public required int Minuto { get; init; }
        public required int NumeroTimeout { get; init; }
        public required bool EsPrimeraMitad { get; init; }
    }
}
