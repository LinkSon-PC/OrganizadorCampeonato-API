using OrganizadorCampeonato.Dominio.Comunes;
using OrganizadorCampeonato.Dominio.Enum;
using OrganizadorCampeonato.Dominio.Excepciones;
using System;

namespace OrganizadorCampeonato.Dominio.Entidades
{
    public class TiempoMuerto : EntidadAuditable<Guid>
    {
        private TiempoMuerto() { }

        public TiempoMuerto(Guid id, Guid partidoId, Guid equipoId, TipoPeriodo periodo, int minuto, int numeroTimeout, bool esPrimeraMitad) : base(id)
        {
            ValidarMinuto(minuto);
            ValidarNumeroTimeout(numeroTimeout);

            PartidoId = partidoId;
            EquipoId = equipoId;
            Periodo = periodo;
            Minuto = minuto;
            NumeroTimeout = numeroTimeout;
            EsPrimeraMitad = esPrimeraMitad;
        }

        public Guid PartidoId { get; init; }
        public Guid EquipoId { get; init; }
        public TipoPeriodo Periodo { get; init; }
        public int Minuto { get; init; }
        public int NumeroTimeout { get; init; }
        public bool EsPrimeraMitad { get; init; }

        public Partido Partido { get; init; } = null!;
        public Equipo Equipo { get; init; } = null!;

        private void ValidarMinuto(int minuto)
        {
            if (minuto < 0 || minuto > 45)
                throw new ExcepcionReglaDeNegocio("El minuto debe estar entre 0 y 45");
        }

        private void ValidarNumeroTimeout(int numeroTimeout)
        {
            if (numeroTimeout < 1)
                throw new ExcepcionReglaDeNegocio("El número de timeout debe ser mayor a 0");
        }
    }
}
