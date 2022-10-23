using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Watchlist.Data.Models;
using Watchlist.Models;
using Watchlist.Services.Contracts;

namespace Watchlist.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly SignInManager<User> _signInManager;

        public UserController(IUserService userService,
            SignInManager<User> signInManager)
        {
            _userService = userService;
            _signInManager = signInManager; 
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            var model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            

            try
            {
                var result = await _userService.SignInUserAsync(model);

                if (result.Succeeded)
                {
                    return RedirectToAction("All", "Movies");
                }

                ModelState.AddModelError("", "Invalid login!");

                return View(model);
            }
            catch (ArgumentNullException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }

        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            var model = new RegisterViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _userService.SignUpUserAsync(model);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View(model);
                }
            }

            return RedirectToAction("Login", "User");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
