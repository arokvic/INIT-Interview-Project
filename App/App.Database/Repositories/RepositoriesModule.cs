using App.Domain.Ports.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace App.Database.Repositories
{
    public static class RepositoriesModule
    {
        public static void AddRepsotiories(this IServiceCollection services)
        {
            services.AddScoped<ICarRepository, CarRepository>();
        }
    }
}
