using AutoMapper;
using ProductShop.Dtos.Export;
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

            CreateMap<Product, ExportProductDto>()
                .ForMember(dest => dest.BuyerName, opt => opt.MapFrom(src => src.Buyer.FirstName + " " + src.Buyer.LastName));
        }
    }
}
