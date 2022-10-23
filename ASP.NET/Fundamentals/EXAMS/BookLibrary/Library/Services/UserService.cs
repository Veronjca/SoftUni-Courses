using Library.Data.Models;
using Library.Models;
using Library.Services.Contracts;
using Microsoft.AspNetCore.Identity;

namespace Library.Services
{
    public class UserService : IUserService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager; 
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
            var user = new ApplicationUser
            {
                Email = model.Email,
                UserName = model.UserName
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            return result;
        }
    }
}
