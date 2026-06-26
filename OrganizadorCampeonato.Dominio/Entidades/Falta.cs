using OrganizadorCampeonato.Dominio.Comunes;
using OrganizadorCampeonato.Dominio.Enum;
using OrganizadorCampeonato.Dominio.Excepciones;
using System;

namespace OrganizadorCampeonato.Dominio.Entidades
{
    public class Falta : EntidadAuditable<Guid>
    {
        private Falta() { }

        public Falta(Guid id, Guid jugadorPartidoId, TipoFalta tipo, TipoPeriodo periodo, int minuto, int numeroFalta) : base(id)
        {
            ValidarMinuto(minuto);
            ValidarNumeroFalta(numeroFalta);

            JugadorPartidoId = jugadorPartidoId;
            Tipo = tipo;
            Periodo = periodo;
            Minuto = minuto;
            NumeroFalta = numeroFalta;
        }

        public Guid JugadorPartidoId { get; init; }
        public TipoFalta Tipo { get; init; }
        public TipoPeriodo Periodo { get; init; }
        public int Minuto { get; init; }
        public int NumeroFalta { get; init; }

        public JugadorPartido JugadorPartido { get; init; } = null!;

        private void ValidarMinuto(int minuto)
        {
            if (minuto < 0 || minuto > 45)
                throw new ExcepcionReglaDeNegocio("El minuto debe estar entre 0 y 45");
        }

        private void ValidarNumeroFalta(int numeroFalta)
        {
            if (numeroFalta < 1)
                throw new ExcepcionReglaDeNegocio("El número de falta debe ser mayor a 0");
        }
    }
}
