using Microsoft.Extensions.DependencyInjection;
using WineTourism.Application.Contracts;
using WineTourism.Infrastructure.Services;

namespace WineTourism.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddScoped<IDestinationService, DestinationService>();
            services.AddScoped<IPdfService, PdfService>();
        }
    }
}
