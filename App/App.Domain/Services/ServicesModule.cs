using App.Domain.Services.Car;
using Microsoft.Extensions.DependencyInjection;

namespace App.Domain.Services
{
    public static class ServicesModule
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICarService, CarService>();
        }
    }
}