using System;
using Microsoft.Extensions.DependencyInjection;

namespace Evoltis.UseCases.Mapper
{
    public static class AutoMapperUseCases
    {
        public static IServiceCollection AddAutoMapperUseCases(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProductsProfile));
            return services;
        }
    }
}

