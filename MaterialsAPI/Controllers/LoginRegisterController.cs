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

        /// <summary>
        /// Login to get authenticated and get authorization
        /// </summary>
        /// <param name="userCredentials">Pass usernam and password</param>
        /// <returns>JWT</returns>
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(UserLoginRegisterDTO))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [Route("LogIn")]
        public async Task<IActionResult> LogInAsync(UserLoginRegisterDTO userCredentials)
        {
            var user = userCredentials;
            var JWT = await _loggingRegisterService.LogInAsync(user.Username, user.Password);
            return Ok(JWT);
        }


        /// <summary>
        /// Register admin, only admins can register other admins
        /// </summary>
        /// <param name="admin">Pass username and password to register</param>
        /// <returns>Role of registered user</returns>
        [HttpPost]
        [Route("registerAdmin")]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(UserLoginRegisterDTO))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> RegisterAdminAsync(UserLoginRegisterDTO admin)
        {
            var registeredUser = await _loggingRegisterService.RegisterUserAsync(admin, "admin");
            return Created("", $"User with {registeredUser.Role} role was registered");
        }

        /// <summary>
        /// Register user
        /// </summary>
        /// <param name="user">Pass username and password to register</param>
        /// <returns>Role of registered user</returns>
        [HttpPost]
        [Route("registerUser")]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(UserLoginRegisterDTO))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUserAsync(UserLoginRegisterDTO user)
        {
            var registeredUser = await _loggingRegisterService.RegisterUserAsync(user, "user");
            return Created("", $"User with {registeredUser.Role} role was registered");
        }
    }
}
