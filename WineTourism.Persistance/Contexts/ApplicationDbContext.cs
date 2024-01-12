using Microsoft.EntityFrameworkCore;
using WineTourism.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace WineTourism.Persistance.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
