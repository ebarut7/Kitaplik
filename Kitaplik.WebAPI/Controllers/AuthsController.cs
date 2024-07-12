using Kitaplik.Business.Abstract;
using Kitaplik.Entities.Concrete;
using Kitaplik.Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Kitaplik.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthsController(IAuthService authService)
        {
            _authService = authService;
        }

        [Route("Token")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            string token = await _authService.CreateTokenAsync(loginDto);
            return string.IsNullOrEmpty(token) ? NotFound() : Ok(token);
        }

        [HttpGet]
        public async Task<IActionResult> GetUser(string userName)
        {
            AppUser user = await _authService.GetUserAsync(userName);
            return user is not null ? Ok(user) : BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserAddDto userAddDto)
        {
            IdentityResult result = await _authService.UserRegisterAsync(userAddDto);
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserDto userDto, string newPassword)
        {
            IdentityResult result = await _authService.UpdatePasswordAsync(userDto.UserName, userDto.Password, newPassword);
            return Ok(result);

        }

    }
}
