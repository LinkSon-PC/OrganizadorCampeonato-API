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
    public class RepositorioTorneoEquipo : Repositorio<TorneoEquipo, Guid>, IRepositorioTorneoEquipo
    {
        private readonly ApplicationDbContext context;

        public RepositorioTorneoEquipo(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public Task<IQueryable<TorneoEquipo>> ObtenerTodosEquipoTorneo(Guid id)
        {
            var query = context.TorneoEquipos
                .Where(t => t.TorneoId == id)
                .Include(e => e.Torneo)
                .Include(e => e.Equipo).AsQueryable();
            return Task.FromResult(query);
        }

        public async Task<TorneoEquipo?> ObtenerPorTorneoYEquipo(Guid torneoId, Guid equipoId)
        {
            return await context.TorneoEquipos
                .FirstOrDefaultAsync(te => te.TorneoId == torneoId && te.EquipoId == equipoId);
        }

        public async Task<bool> ExisteInscripcion(Guid torneoId, Guid equipoId)
        {
            return await context.TorneoEquipos
                .AnyAsync(te => te.TorneoId == torneoId && te.EquipoId == equipoId);
        }
    }
}
