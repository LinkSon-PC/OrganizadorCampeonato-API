using OrganizadorCampeonato.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Torneos.Comandos.ActualizarTorneos
{
    public record ComandoActualizarTorneo
    {
        public required Guid Id { get; init; }
        public required string Nombre { get; init; }
        public required string Lugar { get; init; }
        public string? Descripcion { get; init; }
        public Guid? CategoriaId { get; init; }
        public required FormatoTorneo Formato { get; init; }
        public required DateTime FechaInicio { get; init; }
        public required DateTime FechaFin { get; init; }
    }
}
