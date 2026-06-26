using OrganizadorCampeonato.Dominio.Enum;

namespace OrganizadorCampeonato.Modelos.Faltas
{
    public record RegistrarFaltaDTO
    {
        public required Guid JugadorPartidoId { get; init; }
        public required TipoFalta Tipo { get; init; }
        public required TipoPeriodo Periodo { get; init; }
        public required int Minuto { get; init; }
        public required int NumeroFalta { get; init; }
    }
}
