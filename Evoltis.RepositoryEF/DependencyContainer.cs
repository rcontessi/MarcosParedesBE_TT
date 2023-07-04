using System;
using Evoltis.Entities.Repositories;
using Evoltis.RepositoryEF.DataContext;
using Evoltis.RepositoryEF.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Evoltis.RepositoryEF
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("sqlConnection");
            services.AddDbContext<EvoltisContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );
            services.AddScoped<IProductsRepository, ProductsRepository>();

            return services;
        }
    }
}

