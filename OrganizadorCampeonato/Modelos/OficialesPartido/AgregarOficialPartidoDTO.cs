using OrganizadorCampeonato.Dominio.Enum;

namespace OrganizadorCampeonato.Modelos.OficialesPartido
{
    public record AgregarOficialPartidoDTO
    {
        public required Guid PartidoId { get; init; }
        public required Guid ArbitroId { get; init; }
        public required TipoOficial Rol { get; init; }
    }
}
