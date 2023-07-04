using System;
using Evoltis.UseCasesPort;
using Microsoft.Extensions.DependencyInjection;

namespace Evoltis.UseCases
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<IProductsUseCasesPort, ProductsUseCases>();
            return services;
        }
    }
}

