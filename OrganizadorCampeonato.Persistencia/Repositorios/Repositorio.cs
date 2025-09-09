using Microsoft.EntityFrameworkCore;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Dominio.Comunes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Persistencia.Repositorios
{
    public class Repositorio<T, TId> : IGenericRepository<T, TId>
        where T: EntidadAuditable<TId>
    {
        private readonly ApplicationDbContext context;

        public Repositorio(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Task Actualizar(T entidad)
        {
            context.Update(entidad);
            return Task.CompletedTask;
        }

        public Task<T> Agregar(T entidad)
        {
            context.Add(entidad);
            return Task.FromResult(entidad);
        }

        public Task Borrar(T entidad)
        {
            context.Remove(entidad);
            return Task.CompletedTask;
        }

        public async Task<T?> ObtenerPorId(TId id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public Task<IQueryable<T>> ObtenerTodos()
        {
            var query = context.Set<T>().AsQueryable();
            return Task.FromResult(query);
        }

        public async Task<int> ObtenerTotalRegistros()
        {
            var total = await context.Set<T>().CountAsync();
            return total;
        }
    }
}
