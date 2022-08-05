namespace TeisterMask
{
    using AutoMapper;
    using System;
    using System.Globalization;
    using System.Linq;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ExportDto;
    using TeisterMask.DataProcessor.ImportDto;

    public class TeisterMaskProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE OR RENAME THIS CLASS
        public TeisterMaskProfile()
        {
            CreateMap<TaskDto, Task>()
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => DateTime.ParseExact(src.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None)))
                .ForMember(dest => dest.OpenDate, opt => opt.MapFrom(src => DateTime.ParseExact(src.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None)))
                .ForMember(dest => dest.LabelType, opt => opt.MapFrom(src => Enum.Parse<LabelType>(src.LabelType.ToString())))
                .ForMember(dest => dest.ExecutionType, opt => opt.MapFrom(src => Enum.Parse<ExecutionType>(src.ExecutionType.ToString())));

            CreateMap<ProjectDto, Project>()
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => DateTime.ParseExact(src.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None)))
                .ForMember(dest => dest.OpenDate, opt => opt.MapFrom(src => DateTime.ParseExact(src.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None)));

            CreateMap<EmployeeDto, Employee>();

            CreateMap<Task, ExportTaskDto>()
                .ForMember(dest => dest.TaskName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.OpenDate, opt => opt.MapFrom(src => src.OpenDate.ToString("d", CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate.ToString("d", CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.ExecutionType, opt => opt.MapFrom(src => Enum.Parse<ExecutionType>(src.ExecutionType.ToString())))
                .ForMember(dest => dest.LabelType, opt => opt.MapFrom(src => Enum.Parse<LabelType>(src.LabelType.ToString())));

            CreateMap<Employee, ExportEmployeeDto>();

            CreateMap<Task, ExportTaskForProjectDto>()
                .ForMember(dest => dest.Label, opt => opt.MapFrom(src => src.LabelType));

            CreateMap<Project, ExportProjectDto>()
                .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.TaskCount, opt => opt.MapFrom(src => src.Tasks.Count))
                .ForMember(dest => dest.HasEndDate, opt => opt.MapFrom(src => $"{(src.DueDate != null ? "Yes" : "No")}"))
                .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Tasks.ToList().OrderBy(t => t.Name)));
             

        }
    }
}
