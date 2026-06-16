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
    public class RepositorioPartido : Repositorio<Partido, Guid>, IRepositorioPartido
    {
        private readonly ApplicationDbContext context;

        public RepositorioPartido(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        new public async Task<Partido?> ObtenerPorId(Guid id)
        {
            return await context.Partidos
                .Include(p => p.PartidoEquipos)
                .FirstOrDefaultAsync(p => id == p.Id);
        }
    }
}
