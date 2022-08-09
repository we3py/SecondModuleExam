using MaterialsAPI.DTOs.User;
using MaterialsAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MaterialsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginRegisterController : ControllerBase
    {
        private ILoggingRegisterService _loggingRegisterService;

        public LoginRegisterController(ILoggingRegisterService loggingRegisterService)
        {
            _loggingRegisterService = loggingRegisterService;
        }

        [HttpGet]
        [Route("LogIn")]
        public async Task<IActionResult> LogIn(string name, string password)
        {
            var JWT = await _loggingRegisterService.LogInAsync(name, password);
            return Ok(JWT);
        }

        [HttpPost]
        [Route("registerAdmin")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> RegisterAdmin(UserRegisterDTO admin)
        {
            var registeredUser = await _loggingRegisterService.RegisterUserAsync(admin, "admin");
            return Created("", $"User with {registeredUser.Role} role was registered");
        }

        [HttpPost]
        [Route("registerUser")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUser(UserRegisterDTO user)
        {
            var registeredUser = await _loggingRegisterService.RegisterUserAsync(user, "user");
            return Created("", $"User with {registeredUser.Role} role was registered");
        }
    }
}
