using FilmesIoasys.Dominio.Entidades;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace FilmesIoasys.Infra.Data.Sql
{
    public class DataContext : DbContext
    {
        public DataContext()
        { }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Genero> Generos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Ioasys;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Ignore<Notification>();

            builder.Entity<Usuario>().HasKey(x => x.Id);
            builder.Entity<Pessoa>().HasKey(x => x.Id);
            builder.Entity<Filme>().HasKey(x => x.Id);
            builder.Entity<Genero>().HasKey(x => x.Id);
        }
    }
}
