using OrganizadorCampeonato.Dominio.Entidades;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.ResultadoPeriodos.Consultas.ObtenerResultadoPeriodoPorId
{
    public static class MapeadorResultadoPeriodo
    {
        public static ResultadoPeriodoDTO ADto(this ResultadoPeriodo entity) =>
            new ResultadoPeriodoDTO
            {
                Id = entity.Id,
                PartidoId = entity.PartidoId,
                Periodo = entity.Periodo,
                NumeroProrroga = entity.NumeroProrroga,
                PuntosLocal = entity.PuntosLocal,
                PuntosVisitante = entity.PuntosVisitante,
                FechaCreacion = entity.FechaCreacion,
                UltimaFechaModificacion = entity.UltimaFechaModificacion
            };
    }
}
