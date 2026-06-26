using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Persistencia.Repositorios
{
    public class RepositorioOficialPartido : Repositorio<OficialPartido, Guid>, IRepositorioOficialPartido
    {
        private readonly ApplicationDbContext context;

        public RepositorioOficialPartido(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
