namespace SIS.IRunesApp.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class IRunesDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Track> Tracks { get; set; }
        
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=IRunes;Integrated Security=True;");
        }
    }
}