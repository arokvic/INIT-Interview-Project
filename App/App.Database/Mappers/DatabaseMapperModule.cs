using App.Database.Mappers.CarMapper;
using Microsoft.Extensions.DependencyInjection;

namespace App.Database.Mappers
{
    public static class DatabaseMapperModule
    {
        public static void AddDbMappers(this IServiceCollection services)
        {
            services.AddScoped<ICarMapper,CarMapper.CarMapper>();
        }
    }
}