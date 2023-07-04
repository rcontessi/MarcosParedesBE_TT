using System;
using Evoltis.Entities.Models;
using Evoltis.Entities.Repositories;
using Evoltis.RepositoryEF.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Evoltis.RepositoryEF.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly EvoltisContext evoltisContext;

        public ProductsRepository(EvoltisContext evoltisContext)
        {
            this.evoltisContext = evoltisContext;
        }

        public void Create(Products entity)
        {
            evoltisContext.Products.Add(entity);
            evoltisContext.SaveChanges();
        }

        public Products Delete(Products entity)
        {
            evoltisContext.Remove(entity);
            evoltisContext.SaveChanges();
            return entity;
        }

        public IEnumerable<Products> GetAll()
        {
            return evoltisContext.Products.OrderByDescending(product => product.CreationDate).ToList();
        }

        public Products GetById(int Id)
        {
            return evoltisContext.Products.Find(Id);
        }

        public void Update(Products entity)
        {
            evoltisContext.Entry(entity).State = EntityState.Modified;
            evoltisContext.SaveChanges();
        }
    }
}

