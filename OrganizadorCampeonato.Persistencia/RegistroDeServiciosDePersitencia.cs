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
            services.AddScoped<IRepositorioEquipo, RepositorioEquipo>();
            services.AddScoped<IRepositorioTorneo, RepositorioTorneo>();
            services.AddScoped<IRepositorioPartido, RepositorioPartido>();
            services.AddScoped<IRepositorioPartidoEquipo, RepositorioPartidoEquipo>();
            services.AddScoped<IRepositorioTorneoEquipo, RepositorioTorneoEquipo>();
            services.AddScoped<IRepositorioEquipoJugador, RepositorioEquipoJugador>();
            services.AddScoped<IRepositorioOficialPartido, RepositorioOficialPartido>();
            services.AddScoped<IRepositorioResultadoPeriodo, RepositorioResultadoPeriodo>();
            services.AddScoped<IRepositorioArbitro, RepositorioArbitro>();
            services.AddScoped<IRepositorioJugadorPartido, RepositorioJugadorPartido>();
            services.AddScoped<IRepositorioFalta, RepositorioFalta>();
            services.AddScoped<IRepositorioTiempoMuerto, RepositorioTiempoMuerto>();

            return services;
        }
    }
}
