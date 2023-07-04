using System;
using AutoMapper;
using Evoltis.DTOs;
using Evoltis.Entities.Models;
using Evoltis.Entities.Repositories;
using Evoltis.UseCasesPort;
using static Evoltis.Middleware.Exceptions.BasicExceptions;

namespace Evoltis.UseCases
{
    public class ProductsUseCases : IProductsUseCasesPort
    {
        private readonly IProductsRepository productsRepository;
        private readonly IMapper mapper;

        public ProductsUseCases(IProductsRepository productsRepository,
            IMapper mapper)
        {
            this.productsRepository = productsRepository;
            this.mapper = mapper;
        }

        public ProductsDTO Create(ProductsCreateDTO dto)
        {
            var entity = mapper.Map<Products>(dto);
            entity.CreationDate = DateTime.Now;
            productsRepository.Create(entity);
            return mapper.Map<ProductsDTO>(entity);
        }

        public ProductsDTO Delete(int id)
        {
            var entity = productsRepository.GetById(id);
            if (entity == null)
              throw new NotFoundException("No se encontró el producto");

            productsRepository.Delete(entity);
            return mapper.Map<ProductsDTO>(entity);
        }

        public IEnumerable<ProductsDTO> GetAll()
        {
            return productsRepository.GetAll()
                ?.Select(entity => mapper.Map<ProductsDTO>(entity)) ?? new List<ProductsDTO>();
        }

        public ProductsDTO GetById(int id)
        {
            var entity = productsRepository.GetById(id);
            if (entity == null)
                throw new NotFoundException("No se encontró el producto");

            return mapper.Map<ProductsDTO>(entity);
        }

        public ProductsDTO Update(int id, ProductsCreateDTO dto)
        {
            var entity = productsRepository.GetById(id);
            if (entity == null)
                throw new NotFoundException("No se encontró el producto");

            entity.Name = dto.Name;
            entity.Category = dto.Category;
            entity.Date = dto.Date;
            entity.Stock = dto.Stock;
            productsRepository.Update(entity);

            return mapper.Map<ProductsDTO>(entity);
        }
    }
}

