using System;
using Evoltis.Mapper;
using Evoltis.RepositoryEF;
using Evoltis.UseCases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Evoltis.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddEvoltisDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositories(configuration);
            services.AddUseCases();
            services.AddAutoMapperConfig();

            return services;
        }
    }
}

