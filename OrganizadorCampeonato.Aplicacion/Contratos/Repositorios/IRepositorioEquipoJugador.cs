using OrganizadorCampeonato.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.Contratos.Repositorios
{
    public interface IRepositorioEquipoJugador : IGenericRepository<EquipoJugador, Guid>
    {
        Task<bool> ExisteInscripcion(Guid equipoId, Guid jugadorId);
        Task<IEnumerable<EquipoJugador>> ObtenerPorEquipo(Guid equipoId);
        Task<EquipoJugador?> ObtenerPorEquipoYJugador(Guid equipoId, Guid jugadorId);
    }
}
