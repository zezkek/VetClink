using Microsoft.EntityFrameworkCore;
using VetClink.Models;

namespace VetClink.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }
        public DbSet<Worker> Worker { get; set; }

    }
}
