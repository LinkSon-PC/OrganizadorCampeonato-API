using OrganizadorCampeonato.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.TorneoEquipos.Consultas.ObtenerEquiposPorTorneo
{
    public static class MapeadorTorneoEquipo
    {
        public static TorneoEquipoDTO ADto(this TorneoEquipo torneoEquipo) =>
            new TorneoEquipoDTO
            {
                EquipoId = torneoEquipo.EquipoId,
                NombreEquipo = torneoEquipo.Equipo.Nombre,
                FechaInscripcion = torneoEquipo.FechaInscripcion,
                Posicion = torneoEquipo.Posicion,
                Estado = torneoEquipo.Estado
            };
    }
}
