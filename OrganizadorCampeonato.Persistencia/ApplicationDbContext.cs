using Microsoft.EntityFrameworkCore;
using OrganizadorCampeonato.Dominio.Comunes;
using OrganizadorCampeonato.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Persistencia
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected ApplicationDbContext()
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntidadAuditable<Guid>>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Property("FechaCreacion").CurrentValue = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Property("UltimaFechaModificacion").CurrentValue = DateTime.UtcNow;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Jugador> Jugadores { get; set; }
        public DbSet<Entrenador> Entrenadores { get; set; }
        public DbSet<Arbitro> Arbitros { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Torneo> Torneos { get; set; }
        public DbSet<TorneoEquipo> TorneoEquipos { get; set; }
        public DbSet<Partido> Partidos { get; set; }
        public DbSet<PartidoEquipo> PartidoEquipos { get; set; }
        public DbSet<PartidoArbitro> PartidoArbitros { get; set; }
        public DbSet<ResultadoPeriodo> ResultadosPeriodos { get; set; }
        public DbSet<EquipoJugador> EquipoJugadores { get; set; }
    }
}
