using OrganizadorCampeonato.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Personas.Consultas.ObtenerTodos
{
    public static class MapeadorPersona
    {
        public static PersonaDTO ADto (this Persona persona)
        {
            return new PersonaDTO
            {
                Id = persona.Id,
                Nombres = persona.Nombres,
                Apellidos = persona.Apellidos,
                Identificacion = persona.Identificacion,
                FechaNaciemiento = persona.FechaNaciemiento,
                Telefono = persona.Telefono
            };
        }
    }
}
