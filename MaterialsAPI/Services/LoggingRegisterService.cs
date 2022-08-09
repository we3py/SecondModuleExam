using MaterialsAPI.DTOs.User;
using MaterialsAPI.UsersDATA;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MaterialsAPI.Services
{
    public class LoggingRegisterService : ILoggingRegisterService
    {
        private IMapper _mapper;
        private readonly IConfiguration _config;
        private IUserRepository _userRepository;

        public LoggingRegisterService(IMapper mapper, IUserRepository userRepository, IConfiguration configuration)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _config = configuration;
        }

        public async Task<User> RegisterUserAsync(UserLoginRegisterDTO userToRegister, string role)
        {
            var user = _mapper.Map<User>(userToRegister);
            user.Role = role;
            _userRepository.AddUser(user);
            _userRepository.SaveAsync();

            return user;
        }

        public async Task<string> LogInAsync(string username, string password)
        {
            var user = await _userRepository.GetUserByCredentials(username, password);
            if (user == null)
                throw new KeyNotFoundException("Wrong credentials");

            return await Task.Run(() => GenereateJWT(user));
        }

        private string GenereateJWT(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], claims, expires: DateTime.Now.AddMinutes(15), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
