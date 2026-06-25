using OrganizadorCampeonato.Dominio.Entidades;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.ResultadoPeriodos.Consultas.ObtenerTodosResultadoPeriodos
{
    public static class MapeadorListadoResultadoPeriodo
    {
        public static ListadoResultadoPeriodoDTO ADto(this ResultadoPeriodo entity) =>
            new ListadoResultadoPeriodoDTO
            {
                Id = entity.Id,
                PartidoId = entity.PartidoId,
                Periodo = entity.Periodo,
                EquipoId = entity.EquipoId,
                FechaCreacion = entity.FechaCreacion
            };
    }
}
