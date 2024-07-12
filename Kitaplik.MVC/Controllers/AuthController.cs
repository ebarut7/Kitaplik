using Kitaplik.Business.Abstract;
using Kitaplik.Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Kitaplik.MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserAddDto userAddDto)
        {
            bool res = (await _authService.UserRegisterAsync(userAddDto)).Succeeded;
            return res == true ? View(userAddDto) : View("Register");

        }

        [HttpGet]
        public IActionResult Login()
        { 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            Microsoft.AspNetCore.Identity.SignInResult response = await _authService.LoginAsync(loginDto);
            return RedirectToAction("Index", "Home");
        }
    }
}
