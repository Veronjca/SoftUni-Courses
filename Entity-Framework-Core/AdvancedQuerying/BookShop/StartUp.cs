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
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            Console.WriteLine(GetMostRecentBooks(db));
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

        //08. Author Search

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Select(a => new
                {
                    FirstName = a.FirstName,
                    LastName = a.LastName
                })
                .Where(a => a.FirstName.EndsWith(input))
                .OrderBy(a => a.FirstName + " " + a.LastName)
                .ToList();

            StringBuilder result = new StringBuilder();

            foreach (var author in authors)
            {
                result.AppendLine($"{author.FirstName} {author.LastName}");
            }

            return result.ToString().TrimEnd();
        }

        //09. Book Search
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Select(b => new
                {
                    Title = b.Title
                })
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .ToList();

            StringBuilder result = new StringBuilder();

            foreach (var book in books)
            {
                result.AppendLine(book.Title);
            }

            return result.ToString().TrimEnd();
        }

        //10. Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Include(b => b.Author)
                .Select(b => new
                {
                    BookId = b.BookId,
                    Title = b.Title,
                    AuthorFirstName = b.Author.FirstName,
                    AuthorLastName = b.Author.LastName
                })
                .Where(b => b.AuthorLastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .ToList();

            StringBuilder result = new StringBuilder();

            foreach (var book in books)
            {
                result.AppendLine($"{book.Title} ({book.AuthorFirstName} {book.AuthorLastName})");
            }

            return result.ToString().TrimEnd();
        }

        //11. Count Books
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books
                .Select(b => new
                {
                    Title = b.Title
                })
                .Where(b => b.Title.ToCharArray().Count() > lengthCheck)
                .ToList();

            return books.Count;
        }

        //12. Total Book Copies
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Include(a => a.Books)
                .Select(a => new
                {
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    TotalBookCopies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.TotalBookCopies)
                .ToList();

            StringBuilder result = new StringBuilder();

            foreach (var author in authors)
            {
                result.AppendLine($"{author.FirstName} {author.LastName} - {author.TotalBookCopies}");
            }

            return result.ToString().TrimEnd();
        }

        //13. Profit by Category
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .Include(c => c.CategoryBooks)
                .ThenInclude(cb => cb.Book)
                .Select(c => new
                {
                    Name = c.Name,
                    TotalProfit = c.CategoryBooks.Sum(cb => cb.Book.Price * cb.Book.Copies)
                })
                .OrderByDescending(c => c.TotalProfit)
                .ThenBy(c => c.Name)
                .ToList();

                StringBuilder result = new StringBuilder();

            foreach (var category in categories)
            {
                result.AppendLine($"{category.Name} ${category.TotalProfit}");
            }

            return result.ToString().TrimEnd();
        }

        //14. Most Recent Books
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categoriesBooks = context.Categories
                .Include(c => c.CategoryBooks)
                .ThenInclude(cb => cb.Book)
                .Select(c => new
                {
                    Books = c.CategoryBooks
                              .Select(cb => new
                              {
                                  Title = cb.Book.Title,
                                  ReleaseDate = cb.Book.ReleaseDate,
                                  ReleaseYear = cb.Book.ReleaseDate.Value.Year
                              })
                              .OrderByDescending(cb => cb.ReleaseDate)
                              .Take(3)
                              .ToList(),
                    Name = c.Name
                })
                .OrderBy(c => c.Name)
                .ToList();

            StringBuilder result = new StringBuilder();

            foreach (var cb in categoriesBooks)
            {
                result.AppendLine($"--{cb.Name}");
                foreach (var book in cb.Books)
                {
                    result.AppendLine($"{book.Title} ({book.ReleaseYear})");
                }
            }

            return result.ToString().TrimEnd();
        }

        //15. Increase Prices
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        //16. Remove Books
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 4200)
                .ToList();

            int count = books.Count;

            context.RemoveRange(books);
            context.SaveChanges();

            return count;
        }
    }
}
