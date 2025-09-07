using OrganizadorCampeonato.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Personas.Consultas.ObtenerPorId
{
    public static class MapeadorPersona
    {
        public static PersonaDTO ADto(this Persona persona) => new PersonaDTO
        {
            Id = persona.Id,
            Nombres = persona.Nombres,
            Apellidos = persona.Apellidos,
            Identificacion = persona.Identificacion,
            Genero = persona.Genero,
            FechaNaciemiento = persona.FechaNacimiento,
            Telefono = persona.Telefono
        };
    }
}
