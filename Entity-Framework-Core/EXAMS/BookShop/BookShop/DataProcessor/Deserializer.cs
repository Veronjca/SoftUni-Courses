namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            List<BookDto> bookDtos = new List<BookDto>();
            XmlRootAttribute booksRoot = new XmlRootAttribute();
            booksRoot.ElementName = "Books";

            XmlSerializer serializer = new XmlSerializer(typeof(List<BookDto>), booksRoot);

            using (StringReader reader = new StringReader(xmlString))
            {
                bookDtos = (List<BookDto>)serializer.Deserialize(reader);
            }

            StringBuilder output = new StringBuilder();
            List<Book> books = new List<Book>();
            IMapper mapper = CreateMapper();

            foreach (var bookDto in bookDtos)
            {
                if(IsValid(bookDto))
                {
                    bool isDateValid = DateTime.TryParseExact(bookDto.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);

                    bool isGenreValid = Enum.IsDefined(typeof(Genre), bookDto.Genre);

                    if (isDateValid)
                    {
                        if (isGenreValid)
                        {
                            output.AppendLine(string.Format(SuccessfullyImportedBook, bookDto.Name, bookDto.Price));
                            Book currentBook = mapper.Map<Book>(bookDto);
                            books.Add(currentBook);
                        }
                        else
                        {
                            output.AppendLine(string.Format(ErrorMessage));
                        }
                       
                    } 
                    else
                    {
                        output.AppendLine(string.Format(ErrorMessage));
                    }
                   
                }
                else
                {
                    output.AppendLine(string.Format(ErrorMessage));
                }
            }

            context.AddRange(books);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            List<AuthorDto> authorDtos = JsonConvert.DeserializeObject<List<AuthorDto>>(jsonString);

            List<int> existingBooksIds = context.Books
                .Select(b => b.Id)
                .ToList();

            IMapper mapper = CreateMapper();
            List<Author> authors = new List<Author>();
            StringBuilder output = new StringBuilder();

            foreach (var authorDto in authorDtos)
            {
                Author currentAuthor = new Author();
                List<AuthorBook> authorBooks = new List<AuthorBook>();
                bool flag = true;

                if(IsValid(authorDto))
                {
                    foreach (var author in authors)
                    {
                        if(author.Email == authorDto.Email)
                        {
                            flag = false;
                            break;
                        }
                    }

                    foreach (var bookId in authorDto.Books)
                    {
                        if (bookId.Id != null && existingBooksIds.Contains((int)bookId.Id) )
                        {
                            authorBooks.Add(new AuthorBook { AuthorId = currentAuthor.Id, BookId = (int)bookId.Id });
                        }
                    }

                }

                if(authorBooks.Any() && flag)
                {
                    currentAuthor.Email = authorDto.Email;
                    currentAuthor.FirstName = authorDto.FirstName;
                    currentAuthor.LastName = authorDto.LastName;
                    currentAuthor.Phone = authorDto.Phone;
                    currentAuthor.AuthorsBooks = authorBooks;
                    authors.Add(currentAuthor);
                    output.AppendLine(string.Format(SuccessfullyImportedAuthor, $"{currentAuthor.FirstName + " " + currentAuthor.LastName}", currentAuthor.AuthorsBooks.Count));
                }
                else
                {
                    output.AppendLine(ErrorMessage);
                }
            }

            context.AddRange(authors);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
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
    }
}