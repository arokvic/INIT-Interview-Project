using App.Api.ApiMappers.CarApiMapper;
using Microsoft.Extensions.DependencyInjection;

namespace App.Api.ApiMappers
{
    public static class ApiMapperModule
    {
        public static void AddApiMappers(this IServiceCollection services)
        {
            services.AddScoped<ICarApiMapper, CarApiMapper.CarApiMapper>();
        }
    }
}
