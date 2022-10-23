using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Watchlist.Data.Models;

namespace Watchlist.Data
{
    public class WatchlistDbContext : IdentityDbContext<User>
    {
        public WatchlistDbContext(DbContextOptions<WatchlistDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Movie> Movies { get; set; }
        
        public virtual DbSet<Genre> Genres { get; set; }

        public virtual DbSet<UserMovie> UserMovies { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<UserMovie>()
                .HasKey(us => new { us.UserId, us.MovieId });

            builder.Entity<User>()
                .Property("UserName")
                .HasMaxLength(20);

            builder.Entity<User>()
              .Property("Email")
              .HasMaxLength(60);

            builder.Entity<Movie>()
                .HasOne(m => m.Genre)
                .WithMany(g => g.Movies);

            builder
               .Entity<Genre>()
               .HasData(new Genre()
               {
                   Id = 1,
                   Name = "Action"
               },
               new Genre()
               {
                   Id = 2,
                   Name = "Comedy"
               },
               new Genre()
               {
                   Id = 3,
                   Name = "Drama"
               },
               new Genre()
               {
                   Id = 4,
                   Name = "Horror"
               },
               new Genre()
               {
                   Id = 5,
                   Name = "Romantic"
               });

        }
    }
}