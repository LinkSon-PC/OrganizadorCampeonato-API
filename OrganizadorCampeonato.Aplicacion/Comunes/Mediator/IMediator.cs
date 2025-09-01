using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.Comunes.Mediator
{
    public interface IMediator
    {
        Task Send(IRequest request);
        Task<TResponse> Send<TResponse>(IRequest<TResponse> request);
    }
}
