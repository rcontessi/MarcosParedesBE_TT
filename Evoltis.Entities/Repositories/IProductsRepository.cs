using System;
using Evoltis.Entities.Models;

namespace Evoltis.Entities.Repositories
{
    public interface IProductsRepository
    {
        IEnumerable<Products> GetAll();
        Products GetById(int Id);
        Products Delete(Products entity);
        void Create(Products entity);
        void Update(Products entity);
    }
}

