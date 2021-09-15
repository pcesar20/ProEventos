using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence
{
    public class ProEventosContext : DbContext
    {
        public ProEventosContext(DbContextOptions<ProEventosContext> options) : base(options)
        {

        }
        public DbSet<Evento> Eventos{ get; set; }

        public DbSet<Lote> Lotes{ get; set; }

        public DbSet<Palestrante> Palestrantes{ get; set; }

        public DbSet<PalestranteEventos> PalestrantesEventos{ get; set; }

        public DbSet<RedeSocial> RedeSociais{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalestranteEventos>()
            .HasKey(PE => new {PE.EventoId, PE.PalestranteId});
            base.OnModelCreating(modelBuilder);
        }
    }
}