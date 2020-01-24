using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SweeneyVidyaGames.Api.Models;
using SweeneyVidyaGames.Web.Models;

namespace SweeneyVidyaGames.Api.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<VideoGameDTO> VideoGames { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

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

            // TODO: Remove this later
            builder.Entity<VideoGameDTO>().HasData
                (
                    new VideoGameDTO
                    {
                        Id = 100,
                        Title = "Super Mario Bros 3",
                        Platform = "Nintendo",
                        DateAdded = new DateTime(2001, 01, 10),
                        Released = new DateTime(1972, 09, 10),
                        PlatformApplication = null,
                        ImagePath = "http://fakeimg.com",
                        Rating = 4.5F,
                        Genre = EGenreType.PLATFORMER
                    }
                );
        }
    }
}
