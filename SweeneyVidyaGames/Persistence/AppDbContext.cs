using Microsoft.EntityFrameworkCore;
using SweeneyVidyaGames.Api.Models;

namespace SweeneyVidyaGames.Api.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<VideoGameDTO> VideoGames { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<VideoGameDTO>().ToTable("VideoGames");
            builder.Entity<VideoGameDTO>().HasKey(p => p.Id);
            builder.Entity<VideoGameDTO>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<VideoGameDTO>().Property(p => p.Title).IsRequired();
            builder.Entity<VideoGameDTO>().Property(p => p.Platform).IsRequired();
            builder.Entity<VideoGameDTO>().Property(p => p.DateAdded);
            builder.Entity<VideoGameDTO>().Property(p => p.Genre);
            builder.Entity<VideoGameDTO>().Property(p => p.Released);
            builder.Entity<VideoGameDTO>().Property(p => p.PlatformApplication);
            builder.Entity<VideoGameDTO>().Property(p => p.Rating);
            builder.Entity<VideoGameDTO>().Property(p => p.ImagePath);
        }
    }
}
