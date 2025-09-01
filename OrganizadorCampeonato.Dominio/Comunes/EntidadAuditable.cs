using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Dominio.Comunes
{
    public abstract class EntidadAuditable<TId>
    {
        public TId Id { get; protected set; } = default(TId)!;
        public string? CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string? UltimaModificacionPor { get; set; }
        public DateTime? UltimaFechaModificacion { get; set; }
    }
}
