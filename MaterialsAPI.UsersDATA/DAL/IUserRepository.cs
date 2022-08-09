namespace MaterialsAPI.UsersDATA
{
    public interface IUserRepository
    {
        Task AddUser(User userToAdd);
        Task<User> GetUserByCredentials(string username, string password);
        Task SaveAsync();
    }
}