using Evoltis.UseCases.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace Evoltis.Mapper
{
    public static class AutoMapperConfig
    {
        public static IServiceCollection AddAutoMapperConfig(this IServiceCollection services)
        {
            services.AddAutoMapperUseCases();
            return services;
        }
    }
}

