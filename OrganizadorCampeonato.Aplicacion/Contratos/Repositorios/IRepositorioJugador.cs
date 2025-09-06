using OrganizadorCampeonato.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.Contratos.Repositorios
{
    public interface IRepositorioJugador : IGenericRepository<Jugador, Guid>
    {
        Task AsignarComoJugador(Guid Id);
        Task<IEnumerable<Jugador>> ObtenerTodosJugadores();
    }
}
