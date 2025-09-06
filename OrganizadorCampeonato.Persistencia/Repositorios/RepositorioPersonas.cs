using Microsoft.EntityFrameworkCore;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Persistencia.Repositorios
{
    public class RepositorioPersonas : Repositorio<Persona, Guid>, IRepositorioPersona
    {
        private readonly ApplicationDbContext context;

        public RepositorioPersonas(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<bool> IdentificacionYaRegistrada(string identificacion)
        {
            return await context.Personas.AnyAsync(x => x.Identificacion.Equals(identificacion));
        }

        public async Task<Persona?> ObtenerPorIdentificacion(string identificacion)
        {
            return await context.Personas.FirstOrDefaultAsync(x => x.Identificacion.Equals(identificacion));
        }

        public async Task<bool> PersonaComoJugador(string identificacion)
        {
            var persona = await context.Personas.Include(x => x.Jugador)
                .FirstOrDefaultAsync(x => x.Identificacion.Equals(identificacion));

            return persona?.Jugador != null;
        }
    }
}
