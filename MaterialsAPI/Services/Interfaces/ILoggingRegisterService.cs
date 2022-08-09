namespace MaterialsAPI.Services
{
    public interface ILoggingRegisterService
    {
        Task<string> LogInAsync(string username, string password);
        Task<User> RegisterUserAsync(UserLoginRegisterDTO userToRegister, string Role);
    }
}