namespace Footballers
{
    using AutoMapper;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ExportDto;
    using Footballers.DataProcessor.ImportDto;
    using System;
    using System.Globalization;
    using System.Linq;

    public class FootballersProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE OR RENAME THIS CLASS
        public FootballersProfile()
        {
            //Locally runs perfectly, butd judge doesn't like it :(

            //CreateMap<FootballerDto, Footballer>()
            //    .ForMember(dest => dest.BestSkillType, opt => opt.MapFrom(src => Enum.Parse<BestSkillType>(src.BestSkillType.ToString())))
            //    .ForMember(dest => dest.PositionType, opt => opt.MapFrom(src => Enum.Parse<PositionType>(src.PositionType.ToString())))
            //    .ForMember(dest => dest.ContractStartDate, opt => opt.MapFrom(src => DateTime.ParseExact(src.ContractStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None)))
            //    .ForMember(dest => dest.ContractStartDate, opt => opt.MapFrom(src => DateTime.ParseExact(src.ContractStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None)));

            //CreateMap<CoachDto, Coach>();

            CreateMap<TeamDto, Team>();

            CreateMap<Footballer, ExportFootballerDto>()
                .ForMember(dest => dest.FootballerName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ContractEndDate, opt => opt.MapFrom(src => src.ContractEndDate.ToString("d", CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.ContractStartDate, opt => opt.MapFrom(src => src.ContractStartDate.ToString("d", CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.PositionType, opt => opt.MapFrom(src => src.PositionType.ToString()))
                .ForMember(dest => dest.BestSkillType, opt => opt.MapFrom(src => src.BestSkillType.ToString()));

            CreateMap<Team, ExportTeamDto>();

            CreateMap<Footballer, ExportFootballerWithCoachDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.PositionType.ToString()));

            CreateMap<Coach, ExportCoachDto>()
                .ForMember(dest => dest.CoachName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.FootballersCount, opt => opt.MapFrom(src => src.Footballers.Count))
                .ForMember(dest => dest.Footballers, opt => opt.MapFrom(src => src.Footballers.ToList().OrderBy(f => f.Name)));
        }
    }
}
