using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Persistencia.Repositorios
{
    public class RepositorioPartidoEquipo : Repositorio<PartidoEquipo, Guid>, IRepositorioPartidoEquipo
    {
        private readonly ApplicationDbContext context;

        public RepositorioPartidoEquipo(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
