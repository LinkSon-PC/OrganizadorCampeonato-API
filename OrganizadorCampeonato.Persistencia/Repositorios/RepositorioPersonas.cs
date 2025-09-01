using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Persistencia.Repositorios
{
    public class RepositorioPersonas : Repositorio<Persona, Guid>, IRepositorioPersona
    {
        public RepositorioPersonas(ApplicationDbContext context) : base(context)
        {
        }
    }
}
