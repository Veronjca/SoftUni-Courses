namespace BookShop
{
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static IFormatProvider Culture { get; private set; }

        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            Console.WriteLine(GetBooksReleasedBefore(db, "12-04-1992"));
        }

        //02. Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var titles = context.Books
                .Select(b => new
                {
                    Title = b.Title,
                    Restriction = b.AgeRestriction
                }) 
                .OrderBy(b => b.Title)
                .ToList()
                .Where(b => b.Restriction.ToString().ToLower() == command.ToLower());

            StringBuilder result = new StringBuilder();

            foreach (var title in titles)
            {
                result.AppendLine(title.Title);
            }

            return result.ToString().TrimEnd();
        }

        //03. Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .Select(b => new
                {
                    BookId = b.BookId,
                    Title = b.Title,
                    Copies = b.Copies,
                    EditionType = b.EditionType
                })             
                .OrderBy(b => b.BookId)             
                .ToList()
                .Where(b => b.Copies < 5000 && b.EditionType.ToString() == "Gold");

            StringBuilder result = new StringBuilder();

            foreach (var book in books)
            {
                result.AppendLine(book.Title);
            }

            return result.ToString().TrimEnd();
        }

        //04. Books by Price

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Select(b => new
                {
                    Title = b.Title,
                    Price = b.Price
                })
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .ToList();

            StringBuilder result = new StringBuilder();

            foreach (var book in books)
            {
                result.AppendLine($"{book.Title} - ${book.Price:F2}");
            }

            return result.ToString().TrimEnd();
        }

        //05. Not Released In

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Select(b => new
                {
                    BookId = b.BookId,
                    Title = b.Title,
                    Year = b.ReleaseDate.Value.Year
                })
                .Where(b => b.Year != year)
                .OrderBy(b => b.BookId)
                .ToList();

            StringBuilder result = new StringBuilder();

            foreach (var book in books)
            {
                result.AppendLine(book.Title);
            }

            return result.ToString().TrimEnd();
        }

        //06. Book Titles by Category

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            List<string> categories = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => x.ToLower()).ToList();

            var books = context.Books
                .Include(b => b.BookCategories)
                .ThenInclude(bc => bc.Category)
                .Select(b => new
                {
                    Title = b.Title,
                    Category = b.BookCategories.Select(bc => bc.Category.Name).FirstOrDefault()
                })
                .Where(b => categories.Contains(b.Category.ToLower()))
                .OrderBy(b => b.Title)
                .ToList();

            StringBuilder result = new StringBuilder();

            foreach (var book in books)
            {
                result.AppendLine(book.Title);
            }

            return result.ToString().TrimEnd();
        }

        //07. Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {

            var books = context.Books
                .Select(b => new
                {
                    Title = b.Title,
                    Price = b.Price,
                    EditionType = b.EditionType,
                    ReleaseDate = b.ReleaseDate
                })
                .Where(b => b.ReleaseDate < DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                .OrderByDescending(b => b.ReleaseDate)
                .ToList();

            StringBuilder result = new StringBuilder();

            foreach (var book in books)
            {
                result.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
