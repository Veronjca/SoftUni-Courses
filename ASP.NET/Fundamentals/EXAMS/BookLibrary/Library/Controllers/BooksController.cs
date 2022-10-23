using Library.Models;
using Library.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Library.Controllers
{
    public class BooksController : BaseController
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            this._booksService = booksService;
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddBookViewModel();
            var categories = await _booksService.GetAllCategoriesAsync();

            model.Categories = categories;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await _booksService.AddBookAsync(model);

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
            var books = await _booksService.GetAllBooksAsync();

            return View(books);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int bookId)
        {
            try
            {
                await _booksService.AddToCollectionAsync(bookId, UserId);
            }
            catch (Exception)
            {
            }

            return RedirectToAction("All", "Books");
        }

        [HttpPost]

        public async Task<IActionResult> RemoveFromCollection(int bookId)
        {
            try
            {
                await _booksService.RemoveFromCollectionAsync(bookId, UserId);

                return RedirectToAction("Mine", "Books");
            }
            catch (Exception)
            {
                return RedirectToAction("Mine", "Books");
            }
        }


        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            try
            {
                var books = await _booksService.GetUserBooksAsync(UserId);

                return View(books);

            }
            catch (Exception)
            {
                return RedirectToAction("All", "Books");
            }
        }
    }
}
