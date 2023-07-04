using System;
using Evoltis.DTOs;

namespace Evoltis.UseCasesPort
{
    public interface IProductsUseCasesPort
    {
        IEnumerable<ProductsDTO> GetAll();
        ProductsDTO GetById(int id);
        ProductsDTO Delete(int id);
        ProductsDTO Create(ProductsCreateDTO dto);
        ProductsDTO Update(int id, ProductsCreateDTO dto);
    }
}

