using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Evoltis.RepositoryEF.DataContext
{
    public class EvoltisContextFactory : IDesignTimeDbContextFactory<EvoltisContext>
    {
        public EvoltisContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=127.0.0.1;Database=EvoltisDB;User Id=root;Password=clave";
            var optionBuilder = new DbContextOptionsBuilder<EvoltisContext>();
            optionBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            return new EvoltisContext(optionBuilder.Options);
        }
    }
}

