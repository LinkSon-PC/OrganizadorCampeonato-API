using OrganizadorCampeonato.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.Contratos.Repositorios
{
    public interface IRepositorioPersona : IGenericRepository<Persona, Guid>
    {
        Task<bool> IdentificacionYaRegistrada(string identificacion);
        Task<bool> PersonaComoJugador(string identificacion);
        Task<Persona?> ObtenerPorIdentificacion(string identificacion);
    }
}
