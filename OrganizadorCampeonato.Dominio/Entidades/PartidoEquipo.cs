using OrganizadorCampeonato.Dominio.Comunes;
using OrganizadorCampeonato.Dominio.Enum;
using OrganizadorCampeonato.Dominio.Excepciones;
using System;

namespace OrganizadorCampeonato.Dominio.Entidades
{
    public class PartidoEquipo : EntidadAuditable<Guid>
    {
        private PartidoEquipo() { }

        public PartidoEquipo(Guid id, Guid partidoId, Guid equipoId, bool esLocal) : base(id)
        {
            PartidoId = partidoId;
            EquipoId = equipoId;
            EsLocal = esLocal;
        }

        public Guid PartidoId { get; private set; }
        public Guid EquipoId { get; private set; }
        public bool EsLocal { get; private set; }
        public bool EsGanador { get; private set; }

        public Partido Partido { get; private set; } = null!;
        public Equipo Equipo { get; private set; } = null!;

        public void MarcarComoGanador(EstadoPartido estadoDelPartido)
        {
            if (estadoDelPartido != EstadoPartido.Completada)
                throw new ExcepcionReglaDeNegocio("Solo se puede marcar ganador en partido completado");
            EsGanador = true;
        }
    }
}