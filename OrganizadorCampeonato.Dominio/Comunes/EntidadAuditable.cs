using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Dominio.Comunes
{
    public abstract class EntidadAuditable<TId> where TId : struct
    {
        public TId Id { get; init; } = default;
        public string? CreadoPor { get; init; }
        public DateTime FechaCreacion { get; init; }
        public string? UltimaModificacionPor { get; init; }
        [ConcurrencyCheck]
        public DateTime UltimaFechaModificacion { get; init; }

        protected EntidadAuditable() 
        { 
            UltimaFechaModificacion = DateTime.UtcNow;
        }
        protected EntidadAuditable(TId id) : this() => Id = id;
    }
}
