using OrganizadorCampeonato.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Equipos.Consultas.ObtenerEquipoPorId
{
    public static class MapeadorListadoEquipos
    {
        public static EquipoDTO ADto(this Equipo equipo) =>
            new EquipoDTO
            {
                Id = equipo.Id,
                Nombre = equipo.Nombre,
                EntrenadorId = equipo.EntrenadorId,
                Nombres = equipo.Entrenador?.Persona?.Nombres,
                Apellidos = equipo.Entrenador?.Persona?.Apellidos
            };
    }
}
