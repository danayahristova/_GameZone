using GameZone.Data.Models;
using Microsoft.EntityFrameworkCore;
using GameZone.Data.Configurations;
namespace GameZone.Data
{
    public class GameZoneDbContext : DbContext
    {
        public GameZoneDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Game> Games { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration<Game>(new GameConfiguration());
            modelBuilder.ApplyConfiguration<Genre>(new GenreConfiguration());
        }
    }
}
