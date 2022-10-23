using Microsoft.AspNetCore.Identity;
using Watchlist.Models;

namespace Watchlist.Services.Contracts
{
    public interface IUserService
    {
        Task<SignInResult> SignInUserAsync(LoginViewModel model);
        Task<IdentityResult> SignUpUserAsync(RegisterViewModel model);
    }
}
