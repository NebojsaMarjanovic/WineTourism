using Microsoft.EntityFrameworkCore;
using WineTourism.Domain.Entities;
using System.Reflection;


namespace WineTourism.Persistance.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() 
        {
            
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
             : base(options)
        {
        }

        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Destination> Cities { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Wine> Wines { get; set; }
        public DbSet<Winery> Wineries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Destination>()
                .HasOne(x => x.Hotel)
                .WithMany()
                .HasForeignKey(x=>x.HotelId)
                .OnDelete(DeleteBehavior.NoAction);

           
            modelBuilder.Entity<Destination>()
                .HasOne(x => x.Winery)
                .WithMany()
                .HasForeignKey(x => x.WineryId)
                .OnDelete(DeleteBehavior.NoAction);

 
            modelBuilder.Entity<Winery>()
                .HasMany(v => v.Wines)
                .WithMany(v => v.Wineries);

            modelBuilder.Entity<Reservation>()
                .HasKey(r => new 
                {   r.DestinationId, 
                    r.UserId, 
                    r.Id });

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Destination)
                .WithMany(g => g.Reservations)
                .HasForeignKey(r => r.DestinationId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.User)
                .WithMany(k => k.Reservations)
                .HasForeignKey(r => r.UserId);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
