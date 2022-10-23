using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Watchlist.Data.Models;
using Watchlist.Models;
using Watchlist.Services;
using Watchlist.Services.Contracts;

namespace Watchlist.Controllers
{
    public class MoviesController : BaseController
    {
        private readonly IMoviesService _movieService;

        public MoviesController(IMoviesService moviesService)
        {
            this._movieService = moviesService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddMovieViewModel();
            var genres = await _movieService.GetAllGenresAsync();

            model.Genres = genres;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddMovieViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await _movieService.AddMovieAsync(model);

                return RedirectToAction("All", "Books");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong!");

                return View(model);
            }


        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await _movieService.GetAllMoviesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int movieId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            try
            {
                await _movieService.AddToCollectionAsync(movieId, userId);
            }
            catch (Exception)
            {
            }

            return RedirectToAction("All", "Movies");
        }

        [HttpGet]
        public async Task<IActionResult> Watched()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            try
            {
                var model = await _movieService.GetUserMoviesAsync(userId);

                return View(model);

            }
            catch (Exception)
            {
                return RedirectToAction("All", "Movies");
            }
        }


        [HttpPost]

        public async Task<IActionResult> RemoveFromCollection(int movieId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            try
            {
                await _movieService.RemoveFromCollectionAsync(movieId, userId);

                return RedirectToAction("Watched", "Movies");
            }
            catch (Exception)
            {
                return RedirectToAction("Watched", "Movies");
            }
        }
    }
}
