namespace Footballers.Data
{
    using Footballers.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class FootballersContext : DbContext
    {
        public FootballersContext() { }

        public FootballersContext(DbContextOptions options)
            : base(options) { }

        public virtual DbSet<Coach> Coaches { get; set; }

        public virtual DbSet<Footballer> Footballers { get; set; }

        public virtual DbSet<Team> Teams { get; set; }

        public virtual DbSet<TeamFootballer> TeamsFootballers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamFootballer>()
                .HasKey(tf => new { tf.FootballerId, tf.TeamId });
        }
    }
}
