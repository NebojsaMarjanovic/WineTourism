using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WineTourism.Application.Contracts.Repositories;
using WineTourism.Domain.Entities;
using WineTourism.Persistance.Contexts;
using WineTourism.Persistance.Repositories;

namespace WineTourism.Persistance.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPersistanceLayer(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
            {
                var connectionString = serviceProvider.GetRequiredService<IConfiguration>().GetConnectionString("DefaultConnection");

                options.AddInterceptors(serviceProvider.GetService<ISaveChangesInterceptor>());
                options.UseSqlServer(connectionString);
            });
            //+authentication

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IGenericRepository<Destination>, DestinationRepository>();
            services.AddScoped<IGenericRepository<Reservation>, ReservationRepository>();
            services.AddScoped<IGenericRepository<User>, UserRepository>();
            services.AddScoped<IWineryRepository, WineryRepository>();


            
        }
    }
}
