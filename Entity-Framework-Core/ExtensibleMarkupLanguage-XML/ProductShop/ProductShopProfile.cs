using AutoMapper;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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

            CreateMap<Product, ExportSoldProductsDto>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price.ToString("0.##")));

            CreateMap<User, ExportUserDto>()
                .ForMember(dest => dest.SoldProducts, opt => opt.MapFrom(src => src.ProductsSold));

            CreateMap<Category, ExportCategoryDto>()
                .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.CategoryProducts.Count))
                .ForMember(dest => dest.AveragePrice, opt => opt.MapFrom(src => src.CategoryProducts.Average(p => p.Product.Price)))
                .ForMember(dest => dest.TotalRevenue, opt => opt.MapFrom(src => src.CategoryProducts.Sum(p => p.Product.Price)));

            CreateMap<User, ExportUsersWithProductsDto>()
                .ForMember(dest => dest.SoldProducts, opt => opt.MapFrom(src => src.ProductsSold));

            CreateMap<ICollection<Product>, SoldProductsDto>()
                .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.Count))
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src));
        }
    }
}
