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
    public class RepositorioEntrenador : Repositorio<Entrenador, Guid>, IRepositorioEntrenador
    {
        private readonly ApplicationDbContext context;

        public RepositorioEntrenador(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        new public async Task<Entrenador?> ObtenerPorId(Guid id)
        {
            return await context.Entrenadores
                .Include(e => e.Persona)
                .FirstOrDefaultAsync(e => id == e.Id);
        }

        public Task AsignarComoEntrenador(Guid Id)
        {
            context.Add(new Entrenador(Id));
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Entrenador>> ObtenerTodosEntrenadores()
        {
            return await context.Entrenadores.Include(x => x.Persona).ToListAsync();
        }
    }
}
