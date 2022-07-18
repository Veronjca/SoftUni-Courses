using AutoMapper;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<ProductDto, Product>();

            CreateMap<UserDto, User>();

            CreateMap<CategoryDto, Category>();

            CreateMap<CategoryProductDto, CategoryProduct>();
        }
    }
}
