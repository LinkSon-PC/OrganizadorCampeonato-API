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
    public class RepositorioEquipoJugador : Repositorio<EquipoJugador, Guid>, IRepositorioEquipoJugador
    {
        private readonly ApplicationDbContext context;

        public RepositorioEquipoJugador(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<bool> ExisteInscripcion(Guid equipoId, Guid jugadorId)
        {
            return await context.EquipoJugadores
                .AnyAsync(ej => ej.EquipoId == equipoId && ej.JugadorId == jugadorId);
        }

        public async Task<IEnumerable<EquipoJugador>> ObtenerPorEquipo(Guid equipoId)
        {
            return await context.EquipoJugadores
                .Include(ej => ej.Jugador)
                .ThenInclude(j => j.Persona)
                .Where(ej => ej.EquipoId == equipoId)
                .ToListAsync();
        }

        public async Task<EquipoJugador?> ObtenerPorEquipoYJugador(Guid equipoId, Guid jugadorId)
        {
            return await context.EquipoJugadores
                .FirstOrDefaultAsync(ej => ej.EquipoId == equipoId && ej.JugadorId == jugadorId);
        }
    }
}
