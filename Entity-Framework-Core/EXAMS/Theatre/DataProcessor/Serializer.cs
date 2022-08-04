namespace Theatre.DataProcessor
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theaters = context.Theatres
                .ToList()
                .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count() >= 20)                
                 .Select(t => new
                 {
                     Name = t.Name,
                     Halls = t.NumberOfHalls,
                     TotalIncome = t.Tickets.Where(ts => ts.RowNumber >= 1 && ts.RowNumber <= 5).Sum(ts => ts.Price),
                     Tickets = t.Tickets
                     .Select(ts => new
                     {
                         Price = ts.Price,
                         RowNumber = ts.RowNumber
                     })
                     .Where(ts => ts.RowNumber >= 1 && ts.RowNumber <= 5)
                     .ToList()
                     .OrderByDescending(ts => ts.Price)
                     .ToList()
                 })                
                 .ToList()
                 .OrderByDescending(t => t.Halls)
                 .ThenBy(t => t.Name)
                 .ToList();

            return JsonConvert.SerializeObject(theaters, Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            IMapper mapper = CreateMapper();

            var plays = context.Plays
                .ToList()
                .Where(p => p.Rating <= rating)
                .ToList()
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre.ToString())
                .ToList();

            List<ExportPlayDto> playDtos = mapper.Map<List<ExportPlayDto>>(plays);

            return GenerateOutput<List<ExportPlayDto>>("Plays", playDtos);
        }

        public static IMapper CreateMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<TheatreProfile>();
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
