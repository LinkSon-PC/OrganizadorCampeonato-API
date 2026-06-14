using OrganizadorCampeonato.Dominio.Comunes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Dominio.Entidades
{
    public class TorneoEquipo : EntidadAuditable<Guid>
    {
        private TorneoEquipo() { }
        public TorneoEquipo(Guid torneoId, Guid equipoId)
        {
            TorneoId = torneoId;
            EquipoId = equipoId;
        }

        public Guid TorneoId { get; private set; }
        public Guid EquipoId { get; private set; }
        public Torneo Torneo { get; private set; } = null!;
        public Equipo Equipo { get; private set; } = null!;
    }
}
