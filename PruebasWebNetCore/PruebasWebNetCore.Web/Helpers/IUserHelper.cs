

namespace PruebasWebNetCore.Web.Helpers
{
    using Microsoft.AspNetCore.Identity;
    using PruebasWebNetCore.Web.Data.Entities;
    using PruebasWebNetCore.Web.Models;
    using System.Threading.Tasks;

    public interface IUserHelper
    {
        Task<User> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUSerAsync(User user, string password);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();

        Task<IdentityResult> UpdateUserAsync(User user);

        Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);
    }
}
