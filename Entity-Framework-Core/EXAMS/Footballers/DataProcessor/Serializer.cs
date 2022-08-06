namespace Footballers.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Footballers.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            IMapper mapper = CreateMapper();

            var coaches = context.Coaches
                .Where(c => c.Footballers.Any())
                .ToList()
                .OrderByDescending(c => c.Footballers.Count)
                .ThenBy(c => c.Name)
                .ToList();

            List<ExportCoachDto> coachDtos = mapper.Map<List<ExportCoachDto>>(coaches);

            return GenerateOutput<List<ExportCoachDto>>("Coaches", coachDtos);

        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teams = context.Teams
                .ToList()
                .Select(t => new
                {
                    Name = t.Name,
                    Footballers = t.TeamsFootballers
                    .Select(tf => tf.Footballer)
                    .Where(f => f.ContractStartDate >= date)
                    .ToList()
                    .OrderByDescending(f => f.ContractEndDate)
                    .ThenBy(f => f.Name)
                    .ToList()
                })
                .Where(t => t.Footballers.Any(f => f.ContractStartDate >= date))
                .OrderByDescending(t => t.Footballers.Count)
                .ThenBy(t => t.Name)
                .Take(5)
                .ToList();

            IMapper mapper = CreateMapper();

            List<ExportTeamDto> teamDtos = mapper.Map<List<ExportTeamDto>>(teams);

            return JsonConvert.SerializeObject(teamDtos, Formatting.Indented);
        }

        public static IMapper CreateMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<FootballersProfile>();
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
