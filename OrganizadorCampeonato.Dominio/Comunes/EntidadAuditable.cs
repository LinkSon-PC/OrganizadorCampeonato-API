using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Dominio.Comunes
{
    public abstract class EntidadAuditable<TId>
    {
        public TId Id { get; init; } = default(TId)!;
        public string? CreadoPor { get; init; }
        public DateTime FechaCreacion { get; init; }
        public string? UltimaModificacionPor { get; init; }
        [ConcurrencyCheck]
        public DateTime? UltimaFechaModificacion { get; init; }

        protected EntidadAuditable() { }
        protected EntidadAuditable(TId id) => Id = id;
    }
}
