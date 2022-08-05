namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using AutoMapper;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {

            List<Project> projects = context.Projects
                .Where(p => p.Tasks.Any())
                .ToList()
                .OrderByDescending(p => p.Tasks.Count)
                .ThenBy(p => p.Name)
                .ToList();

            IMapper mapper = CreateMapper();

            List<ExportProjectDto> projectDtos = mapper.Map<List<ExportProjectDto>>(projects);

            return GenerateOutput<List<ExportProjectDto>>("Projects", projectDtos);
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees
                .Include(e => e.EmployeesTasks)
                .ThenInclude(et => et.Task)
                .ToList()
                .Where(e => e.EmployeesTasks.Any(et => et.Task.OpenDate >= date))
                .Select(e => new
                {
                    Username = e.Username,
                    Tasks = e.EmployeesTasks
                    .Select(et => et.Task)
                    .Where(t => t.OpenDate >= date)
                    .ToList()
                    .OrderByDescending(t => t.DueDate)
                    .ThenBy(t => t.Name)
                    .ToList()

                })             
                .ToList()
                .OrderByDescending(e => e.Tasks.Count)
                .ThenBy(e => e.Username)
                .Take(10)
                .ToList();

            IMapper mapper = CreateMapper();

            List<ExportEmployeeDto> employessDtos = mapper.Map<List<ExportEmployeeDto>>(employees);

            return JsonConvert.SerializeObject(employessDtos, Formatting.Indented);
        }

        public static IMapper CreateMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<TeisterMaskProfile>();
                cfg.CreateMissingTypeMaps = true;
            });

            IMapper mapper = config.CreateMapper();
            return mapper;
        }

        public static string GenerateOutput<T>(string rootName, T dtoParam)
        {
            XmlRootAttribute productRoot = new XmlRootAttribute();
            productRoot.ElementName = rootName;

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            XmlSerializer serializer = new XmlSerializer(typeof(T), productRoot);

            using (TextWriter writer = new StreamWriter("result.xml"))
            {
                serializer.Serialize(writer, dtoParam, namespaces);
            }

            string result = File.ReadAllText("result.xml");
            return result;
        }
    }
}