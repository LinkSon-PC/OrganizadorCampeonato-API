using OrganizadorCampeonato.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.Contratos.Repositorios
{
    public interface IRepositorioEntrenador : IGenericRepository<Entrenador, Guid>
    {
        Task AsignarComoEntrenador(Guid Id);
        Task<IEnumerable<Entrenador>> ObtenerTodosEntrenadores();
    }
}
