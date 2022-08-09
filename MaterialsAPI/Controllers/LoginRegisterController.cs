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
        private LoggingRegisterService _loggingRegisterService;

        public LoginRegisterController(LoggingRegisterService loggingRegisterService)
        {
            _loggingRegisterService = loggingRegisterService;
        }

        [HttpGet]
        [Route("LogIn")]
        public async Task<IActionResult> LogIn(string name, string password)
        {
            var JWT = await _loggingRegisterService.LogIn(name, password);
            return Ok(JWT);
        }

        [HttpPost]
        [Route("registerAdmin")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> RegisterAdmin(UserRegisterDTO admin)
        {
            var registeredUser = await _loggingRegisterService.RegisterAdmin(admin);
            return Created("", $"User with {registeredUser} role was registered");
        }

        [HttpPost]
        [Route("registerUser")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUser(UserRegisterDTO user)
        {
            var registeredUser = await _loggingRegisterService.RegisterUser(user);
            return Created("", $"User with {registeredUser} role was registered");
        }
    }
}
