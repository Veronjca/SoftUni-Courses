using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Theatre.Data.Models;
using Theatre.Data.Models.Enums;
using Theatre.DataProcessor.ExportDto;
using Theatre.DataProcessor.ImportDto;

namespace Theatre.Data
{
    public class TheatreProfile : Profile
    {
        public TheatreProfile()
        {
            CreateMap<PlayDto, Play>()
                .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => TimeSpan.ParseExact(src.Duration, "c", CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => Enum.Parse<Genre>(src.Genre)));

            CreateMap<CastDto, Cast>();

            CreateMap<TicketDto, Ticket>();

            CreateMap<TheatreDto, Theatre.Data.Models.Theatre>();

            CreateMap<Play, ExportPlayDto>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => Enum.Parse<Genre>(src.Genre.ToString())))
                .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration.ToString("c", CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.Casts.Where(c => c.IsMainCharacter).ToList().OrderByDescending(a => a.FullName)))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => $"{(src.Rating == 0 ? "Premier" : src.Rating.ToString())}"));

            CreateMap<Cast, ExportActorDto>()
                .ForMember(dest => dest.MainCharacter, opt => opt.MapFrom(src => $"Plays main character in '{src.Play.Title}'."));
        }
    }
}
