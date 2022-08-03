using AutoMapper;
using BookShop.Data.Models;
using BookShop.Data.Models.Enums;
using BookShop.DataProcessor.ExportDto;
using BookShop.DataProcessor.ImportDto;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace BookShop
{
   public class BookShopProfile : Profile
    {
        public BookShopProfile()
        {
            CreateMap<BookDto, Book>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => (Genre)src.Genre))
                .ForMember(dest => dest.PublishedOn, opt => opt.MapFrom(src => DateTime.ParseExact(src.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None)));

            CreateMap<AuthorDto, Author>();

            CreateMap<Book, ExportBookDto>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.PublishedOn.ToString("d", CultureInfo.InvariantCulture)));
                
        }
    }
}
