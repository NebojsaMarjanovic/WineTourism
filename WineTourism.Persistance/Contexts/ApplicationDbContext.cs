using Microsoft.EntityFrameworkCore;
using WineTourism.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace WineTourism.Persistance.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Wine> Wines { get; set; }
        public DbSet<Winery> Wineries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
