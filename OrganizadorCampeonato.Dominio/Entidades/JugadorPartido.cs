using OrganizadorCampeonato.Dominio.Comunes;
using OrganizadorCampeonato.Dominio.Enum;
using OrganizadorCampeonato.Dominio.Excepciones;
using System;
using System.Collections.Generic;

namespace OrganizadorCampeonato.Dominio.Entidades
{
    public class JugadorPartido : EntidadAuditable<Guid>
    {
        private JugadorPartido() { }

        public JugadorPartido(Guid id, Guid partidoEquipoId, Guid jugadorId, int dorsal, bool esCapitan = false, bool esTitular = false) : base(id)
        {
            ValidarDorsal(dorsal);

            PartidoEquipoId = partidoEquipoId;
            JugadorId = jugadorId;
            Dorsal = dorsal;
            EsCapitan = esCapitan;
            EsTitular = esTitular;
            Jugo = false;
        }

        public Guid PartidoEquipoId { get; init; }
        public Guid JugadorId { get; init; }
        public int Dorsal { get; init; }
        public bool EsCapitan { get; init; }
        public bool EsTitular { get; init; }
        public bool Jugo { get; init; }

        public PartidoEquipo PartidoEquipo { get; init; } = null!;
        public Jugador Jugador { get; init; } = null!;
        public List<Falta> Faltas { get; init; } = new();

        private void ValidarDorsal(int dorsal)
        {
            if (dorsal < 0 || dorsal > 99)
                throw new ExcepcionReglaDeNegocio("El dorsal debe estar entre 0 y 99");
        }
    }
}
