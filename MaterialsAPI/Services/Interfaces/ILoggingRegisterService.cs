﻿using MaterialsAPI.DTOs.User;

namespace MaterialsAPI.Services
{
    public interface ILoggingRegisterService
    {
        Task<string> LogInAsync(string username, string password);
        Task<User> RegisterUserAsync(UserRegisterDTO userToRegister, string Role);
    }
}