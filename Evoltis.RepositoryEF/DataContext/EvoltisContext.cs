using System;
using Evoltis.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Evoltis.RepositoryEF.DataContext
{
    public class EvoltisContext : DbContext
    {
        public EvoltisContext(DbContextOptions<EvoltisContext> options) : base(options)
        {
        }

        public DbSet<Products> Products { get; set; }
    }
}

