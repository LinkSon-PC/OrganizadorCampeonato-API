using Microsoft.EntityFrameworkCore;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.Personas.Consultas.ObtenerTodos;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Dominio.Entidades;
using OrganizadorCampeonato.Persistencia.Paginado;
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

        public async Task<bool> PersonaComoEntrenador(string identificacion)
        {
            var persona = await context.Personas.Include(x => x.Entrenador)
                .FirstOrDefaultAsync(x => x.Identificacion.Equals(identificacion));

            return persona?.Jugador != null;
        }

        public async Task<IEnumerable<Persona>> ObtenerPaginado(PersonaPaginacionDTO paginado)
        {
            var query = context.Personas.AsQueryable();

            if(!string.IsNullOrWhiteSpace(paginado.Identificacion))
                query = query.Where(p => p.Identificacion == paginado.Identificacion);

            if(!string.IsNullOrWhiteSpace(paginado.Nombres))
                query = query.Where(p => p.Nombres.Contains(paginado.Nombres));

            if(!string.IsNullOrWhiteSpace(paginado.Apellidos))
                query = query.Where(p => p.Apellidos.Contains(paginado.Apellidos));

            if (!string.IsNullOrWhiteSpace(paginado.Telefono))
                query = query.Where(p => p.Telefono != null && p.Telefono.Contains(paginado.Telefono));

            return await query
                .Paginado(paginado.PageNumber, paginado.PageSize)
                .ToListAsync();
        }
    }
}
