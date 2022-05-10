using Microsoft.EntityFrameworkCore;
using ChallengeOrenes.Entities;

namespace ChallengeOrenes.Data
{    public class AppDbContext : DbContext
    {
        public DbSet<Vehicle> vehicles { get; set; }
        public DbSet<Location> locations { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<User> users { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=OrenesChallenge;Trusted_Connection=True;").LogTo(Console.WriteLine, LogLevel.Information);
        }

    }
}
