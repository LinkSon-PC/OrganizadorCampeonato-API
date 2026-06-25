using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Persistencia.Repositorios
{
    public class RepositorioPartidoArbitro : Repositorio<PartidoArbitro, Guid>, IRepositorioPartidoArbitro
    {
        private readonly ApplicationDbContext context;

        public RepositorioPartidoArbitro(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
