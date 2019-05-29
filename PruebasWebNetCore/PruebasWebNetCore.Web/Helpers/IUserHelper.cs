

namespace PruebasWebNetCore.Web.Helpers
{
    using Microsoft.AspNetCore.Identity;
    using PruebasWebNetCore.Web.Data.Entities;
    using PruebasWebNetCore.Web.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserHelper
    {
        Task<User> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUSerAsync(User user, string password);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();

        Task<IdentityResult> UpdateUserAsync(User user);

        Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword);

        //

        Task<SignInResult> ValidatePasswordAsync(User userm, string password);

        //
        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);

        //


        Task<string> GenerateEmailConfirmationTokenAsync(User user);

        Task<IdentityResult> ConfirmEmailAsync(User user, string token);

        Task<User> GetUserByIdAsync(string userId);


        //

        Task<List<User>> GetAllUsersAsync();

        Task RemoveUserFromRoleAsync(User user, string roleName);

        Task DeleteUserAsync(User user);


    }
}
