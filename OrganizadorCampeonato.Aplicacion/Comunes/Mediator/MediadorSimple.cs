using Microsoft.Extensions.DependencyInjection;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.Comunes.Mediator
{
    public class MediadorSimple : IMediator
    {
        private readonly IServiceProvider service;

        public MediadorSimple(IServiceProvider service)
        {
            this.service = service;
        }

        public async Task Send(IRequest request)
        {
            var tipoCasoDeUso = typeof(IRequestHandler<>).MakeGenericType(request.GetType());

            var casoDeUso = service.GetService(tipoCasoDeUso);

            if (casoDeUso is null)
            {
                throw new ExcepcionDeMediador($"No se encontró un handler para {request.GetType().Name}");
            }

            var metodo = tipoCasoDeUso.GetMethod("Handle")!;
            await (Task)metodo.Invoke(casoDeUso, new object[] { request })!;
        }

        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {
            var tipoCasoDeUso = typeof(IRequestHandler<,>)
                .MakeGenericType(request.GetType(), typeof(TResponse));

            var casoDeUso = service.GetService(tipoCasoDeUso);

            if (casoDeUso is null)
                throw new ExcepcionDeMediador($"No se encontró un handler para {request.GetType().Name}");

            var metodo = tipoCasoDeUso.GetMethod("Handle")!;
            return await (Task<TResponse>)metodo.Invoke(casoDeUso, new object[] { request })!;
        }
    }
}
