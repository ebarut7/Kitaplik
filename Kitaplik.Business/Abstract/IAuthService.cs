using Kitaplik.Entities.Concrete;
using Kitaplik.Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplik.Business.Abstract
{
    public interface IAuthService
    {
        Task<List<string>> GetRolesAsync(AppUser user);
        Task<IdentityResult> RemoveUserAsync(string userName);
        Task<SignInResult> LoginAsync(LoginDto loginDto);
        Task<IdentityResult> PasswordResetAsync(string userName, string newPassword);
        Task<IdentityResult> UpdatePasswordAsync(string userName, string currentPassword, string newPassword);
        Task<IdentityResult> UserRegisterAsync(UserAddDto userAddDto);
        Task<string> CreateTokenAsync(LoginDto loginDto);
        Task<AppUser> GetUserAsync(string userName);
        Task SignOutAsync();
        Task<IdentityResult> AddToRoleAsync(AppUser appUser, string role);

    }
}
