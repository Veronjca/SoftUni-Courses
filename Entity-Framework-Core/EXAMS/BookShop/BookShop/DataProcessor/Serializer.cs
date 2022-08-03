namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using BookShop.Data.Models;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var authors = context.Authors
                 .Select(a => new
                 {
                     AuthorName = $"{a.FirstName} {a.LastName}",
                     Books = a.AuthorsBooks
                     .Select(ab => ab.Book)
                     .OrderByDescending(b => b.Price)
                     .Select(b => new
                     {
                         BookName = b.Name,
                         BookPrice = $"{b.Price:f2}"
                     })
                     .ToList()

                 })
                 .ToList()
                 .OrderByDescending(a => a.Books.Count)
                 .ThenBy(a => a.AuthorName)
                 .ToList();

            return JsonConvert.SerializeObject(authors, Settings());
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            IMapper mapper = CreateMapper();

            var bookDtos = context.Books
                .Where(b => b.PublishedOn < date && b.Genre.ToString() == "Science")
                .OrderByDescending(b => b.Pages)
                .ThenByDescending(b => b.PublishedOn)
                .ProjectTo<ExportBookDto>(mapper.ConfigurationProvider)       
                .Take(10)
                .ToList();

            return GenerateOutput<List<ExportBookDto>>("Books", bookDtos);

        }

        public static JsonSerializerSettings Settings()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            return settings;
        }

        public static IMapper CreateMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BookShopProfile>();
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