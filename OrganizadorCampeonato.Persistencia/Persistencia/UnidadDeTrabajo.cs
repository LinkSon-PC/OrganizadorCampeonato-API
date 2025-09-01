using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Persistencia.Persistencia
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {
        private readonly ApplicationDbContext context;

        public UnidadDeTrabajo(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task Persistir()
        {
            await context.SaveChangesAsync();
        }

        public Task Reversar()
        {
            return Task.CompletedTask;
        }
    }
}
