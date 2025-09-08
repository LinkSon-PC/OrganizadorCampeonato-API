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
    public class RepositorioEquipo : Repositorio<Equipo, Guid>, IRepositorioEquipo
    {
        private readonly ApplicationDbContext context;

        public RepositorioEquipo(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        new public Task<IQueryable<Equipo>> ObtenerTodos() {
            var query = context.Equipos
                .Include(e => e.Entrenador)
                .ThenInclude(e => e.Persona).AsQueryable();
            return Task.FromResult(query);
        }

        new public async Task<Equipo?> ObtenerPorId(Guid id)
        {
            var equipo = await context.Equipos
                .Include(e => e.Entrenador)
                .ThenInclude(e => e.Persona)
                .FirstOrDefaultAsync(e => id == e.Id);
            return equipo;
        }
    }
}
