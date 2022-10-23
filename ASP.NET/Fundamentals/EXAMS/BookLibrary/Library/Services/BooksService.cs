using Library.Data;
using Library.Data.Models;
using Library.Models;
using Library.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BooksService : IBooksService
    {

        private readonly LibraryDbContext _dbContext;

        public BooksService(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddBookAsync(AddBookViewModel model)
        {
            var book = new Book()
            {
                Title = model.Title,
                Author = model.Author,
                CategoryId = model.CategoryId,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                Description = model.Description,                 
            };

            var category = await _dbContext.Categories
                .Where(c => c.Id == model.CategoryId)
                .FirstOrDefaultAsync();

            category.Books.Add(book);
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<Category>> GetAllCategoriesAsync()
        {
            var categories = await _dbContext.Categories.ToListAsync();

            return categories;
        }

        public async Task<ICollection<BookViewModel>> GetAllBooksAsync()
        {
            return await _dbContext.Books
                .Include(b => b.Category)
                .Select(b => new BookViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Category = b.Category.Name,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating   
                })
                .ToListAsync();
        }

        public async Task AddToCollectionAsync(int bookId, string userId)
        {
            var book = _dbContext.Books.FirstOrDefault(x => x.Id == bookId);

            if (book == null)
            {
                throw new ArgumentException("Invalid book Id!");
            }

            var user = await _dbContext.Users
                .Where(u => u.Id == userId)
                .Include(u => u.ApplicationUsersBooks)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user Id!");
            }

            if (user.ApplicationUsersBooks.Any(m => m.BookId == bookId))
            {
                throw new ArgumentException("The book is already added!");
            }

            var userBook = new ApplicationUserBook()
            {
                BookId = bookId,
                ApplicationUserId = userId
            };

            user.ApplicationUsersBooks.Add(userBook);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveFromCollectionAsync(int bookId, string userId)
        {
            var user = await _dbContext.Users
                .Include(u => u.ApplicationUsersBooks)
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user Id!");
            }

            if (!user.ApplicationUsersBooks.Any(us => us.BookId == bookId))
            {
                throw new ArgumentException("Invalid book Id!");
            }

            var userBook = user.ApplicationUsersBooks.Where(us => us.BookId == bookId).FirstOrDefault();

            user.ApplicationUsersBooks.Remove(userBook);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<MineBooksViewModel>> GetUserBooksAsync(string userId)
        {
            var user = await _dbContext.Users
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user Id!");
            }

            var books = await _dbContext.ApplicationUserBooks
                 .Where(us => us.ApplicationUserId == userId)
                 .Select(us => us.Book)
                 .Select(b => new MineBooksViewModel()
                 {
                     Id = b.Id,
                     Title = b.Title,
                     ImageUrl = b.ImageUrl,
                     Author = b.Author,
                     Category = b.Category.Name,
                     Description = b.Description
                 })
                 .ToListAsync();

            return books;
        }
    }
}
