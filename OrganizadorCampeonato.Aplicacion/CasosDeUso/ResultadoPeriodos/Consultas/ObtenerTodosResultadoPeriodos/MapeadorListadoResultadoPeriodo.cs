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
                NumeroProrroga = entity.NumeroProrroga,
                PuntosLocal = entity.PuntosLocal,
                PuntosVisitante = entity.PuntosVisitante,
                FechaCreacion = entity.FechaCreacion
            };
    }
}
