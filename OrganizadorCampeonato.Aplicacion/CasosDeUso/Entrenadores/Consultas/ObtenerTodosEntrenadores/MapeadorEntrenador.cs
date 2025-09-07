using OrganizadorCampeonato.Aplicacion.CasosDeUso.Personas.Consultas.ObtenerTodos;
using OrganizadorCampeonato.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Entrenadores.Consultas.ObtenerTodosEntrenadores
{
    public static class MapeadorEntrenador
    {
        public static ListadoEntrenadorDTO ADto(this Persona persona) =>
            new ListadoEntrenadorDTO
            {
                Id = persona.Id,
                Identificacion = persona.Identificacion,
                Nombres = persona.Nombres,
                Apellidos = persona.Apellidos,
                FechaNaciemiento = persona.FechaNacimiento,
                Genero = persona.Genero,
                Telefono = persona.Telefono
            };
    }
}
