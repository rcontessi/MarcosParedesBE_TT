using System;
using AutoMapper;
using Evoltis.DTOs;
using Evoltis.Entities.Models;

namespace Evoltis.UseCases.Mapper
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<Products, ProductsDTO>();
            CreateMap<ProductsDTO, Products>();
            CreateMap<ProductsCreateDTO, Products>();
        }
    }
}

