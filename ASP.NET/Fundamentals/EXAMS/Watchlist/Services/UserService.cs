using Microsoft.AspNetCore.Identity;
using Watchlist.Data;
using Watchlist.Data.Models;
using Watchlist.Models;
using Watchlist.Services.Contracts;

namespace Watchlist.Services
{
    public class UserService : IUserService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public UserService(SignInManager<User> signInManager,
            UserManager<User> userManager)
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
        }
        public async Task<SignInResult> SignInUserAsync(LoginViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user == null)
            {
                throw new ArgumentNullException("Not found!");
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

            return result;
        }

        public async Task<IdentityResult> SignUpUserAsync(RegisterViewModel model)
        {
            var user = new User
            {
                Email = model.Email,
                UserName = model.UserName
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            return result;
        }
    }
}
