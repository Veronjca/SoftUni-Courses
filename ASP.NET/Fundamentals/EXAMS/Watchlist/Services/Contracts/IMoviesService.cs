using Watchlist.Data.Models;
using Watchlist.Models;

namespace Watchlist.Services.Contracts
{
    public interface IMoviesService
    {
        Task<ICollection<Genre>> GetAllGenresAsync();

        Task<ICollection<MovieViewModel>> GetAllMoviesAsync();

        Task<ICollection<MovieViewModel>> GetUserMoviesAsync(string userId);

        Task AddMovieAsync(AddMovieViewModel model);

        Task AddToCollectionAsync(int movieId, string userId);

        Task RemoveFromCollectionAsync(int movieId, string userId);
    }
}
