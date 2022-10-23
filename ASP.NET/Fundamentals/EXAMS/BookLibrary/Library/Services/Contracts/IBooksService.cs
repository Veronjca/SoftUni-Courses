using Library.Data.Models;
using Library.Models;

namespace Library.Services.Contracts
{
    public interface IBooksService
    {
        Task AddBookAsync(AddBookViewModel model);

        Task<ICollection<Category>> GetAllCategoriesAsync();

        Task<ICollection<BookViewModel>> GetAllBooksAsync();

        Task AddToCollectionAsync(int bookId, string userId);

        Task RemoveFromCollectionAsync(int bookId, string userId);

        Task<ICollection<MineBooksViewModel>> GetUserBooksAsync(string userId);
    }
}
