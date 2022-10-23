using Library.Models;
using Microsoft.AspNetCore.Identity;

namespace Library.Services.Contracts
{
    public interface IUserService
    {
        Task<SignInResult> SignInUserAsync(LoginViewModel model);
        Task<IdentityResult> SignUpUserAsync(RegisterViewModel model);
    }
}
