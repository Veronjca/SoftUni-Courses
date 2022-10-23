using Microsoft.EntityFrameworkCore;
using Watchlist.Data;
using Watchlist.Data.Models;
using Watchlist.Models;
using Watchlist.Services.Contracts;

namespace Watchlist.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly WatchlistDbContext _dbContext;

        public MoviesService(WatchlistDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddMovieAsync(AddMovieViewModel model)
        {
            var movie = new Movie()
            {
                Title = model.Title,
                Director = model.Director,
                GenreId = model.GenreId,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
            };

           await _dbContext.Movies.AddAsync(movie);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddToCollectionAsync(int movieId, string userId)
        {
            var movie = _dbContext.Movies.FirstOrDefault(x => x.Id == movieId);

            if (movie == null)
            {
                throw new ArgumentException("Invalid movie Id!");
            }

            var user = await _dbContext.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UsersMovies)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user Id!");
            }

            if (user.UsersMovies.Any(m => m.MovieId == movieId))
            {
                throw new ArgumentException("The movie is already added!");
            }

            var userMovie = new UserMovie()
            {
                MovieId = movieId,
                UserId = userId
            };

            user.UsersMovies.Add(userMovie);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<Genre>> GetAllGenresAsync()
        {
           var genres = await _dbContext.Genres.ToListAsync();

            return genres;
        }

        public async Task<ICollection<MovieViewModel>> GetAllMoviesAsync()
        {
            return await _dbContext.Movies
                .Select(m => new MovieViewModel()
                {
                    Id = m.Id,
                    Title = m.Title,    
                    Director = m.Director,
                    Rating = m.Rating,
                    ImageUrl = m.ImageUrl,
                    Genre = m.Genre.Name
                })
                .ToListAsync();
        }

        public async Task<ICollection<MovieViewModel>> GetUserMoviesAsync(string userId)
        {
            var user = await _dbContext.Users
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user Id!");
            }

           var movies = await _dbContext.UserMovies
                .Where(us => us.UserId == userId)
                .Select(us => us.Movie)
                .Select(m => new MovieViewModel()
                {
                    Director = m.Director,
                    Genre = m.Genre.Name,
                    Id = m.Id,
                    ImageUrl = m.ImageUrl,
                    Rating = m.Rating,
                    Title = m.Title
                })
                .ToListAsync();

            return movies;
        }

        public async Task RemoveFromCollectionAsync(int movieId, string userId)
        {
            var user = await _dbContext.Users
                .Include(u => u.UsersMovies)
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();

            if(user == null)
            {
                throw new ArgumentException("Invalid user Id!");
            }

            if(!user.UsersMovies.Any(us => us.MovieId == movieId))
            {
                throw new ArgumentException("Invalid movie Id!");
            }

            var userMovie = user.UsersMovies.Where(us => us.MovieId == movieId).FirstOrDefault();

            user.UsersMovies.Remove(userMovie);
            await _dbContext.SaveChangesAsync();
        }
    }
}
