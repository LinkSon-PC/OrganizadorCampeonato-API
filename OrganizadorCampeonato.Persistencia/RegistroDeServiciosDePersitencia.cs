using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Persistencia.Persistencia;
using OrganizadorCampeonato.Persistencia.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Persistencia
{
    public static class RegistroDeServiciosDePersitencia
    {
        public static IServiceCollection AgregarServiciosDePersistencia(this IServiceCollection services) 
        {
            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer("name=DefaultConnection"));

            services.AddScoped<IUnidadDeTrabajo, UnidadDeTrabajo>();
            services.AddScoped<IRepositorioPersona, RepositorioPersonas>();
            services.AddScoped<IRepositorioJugador, RepositorioJugador>();
            services.AddScoped<IRepositorioEntrenador, RepositorioEntrenador>();

            return services;
        }
    }
}
