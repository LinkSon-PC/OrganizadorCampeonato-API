using OrganizadorCampeonato.Dominio.Enum;

namespace OrganizadorCampeonato.Modelos.OficialesPartido
{
    public record ActualizarOficialPartidoDTO
    {
        public required Guid PartidoId { get; init; }
        public required Guid ArbitroId { get; init; }
        public required TipoOficial Rol { get; init; }
    }
}
