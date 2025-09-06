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
    public class RepositorioJugador : Repositorio<Jugador, Guid>, IRepositorioJugador
    {
        private readonly ApplicationDbContext context;

        public RepositorioJugador(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public Task AsignarComoJugador(Guid Id)
        {
            context.Add(new Jugador(Id));
            return Task.CompletedTask; 
        }

        public async Task<IEnumerable<Jugador>> ObtenerTodosJugadores()
        {
            return await context.Jugadores.Include(x => x.Persona).ToListAsync();
        }
    }
}
