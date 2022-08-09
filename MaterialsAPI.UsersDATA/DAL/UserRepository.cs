namespace MaterialsAPI.UsersDATA
{
    public class UserRepository : IUserRepository
    {
        private UserContext _userContext;

        public UserRepository(UserContext userContext)
        {
            _userContext = userContext;
        }

        public async Task AddUser(User userToAdd)
            => await _userContext.Users.AddAsync(userToAdd);

        public async Task<User> GetUserByCredentials(string username, string password)
            => await _userContext.Users
            .Where(u => u.Username == username && u.Password == password)
            .FirstOrDefaultAsync();

        public async Task SaveAsync()
            => await _userContext.SaveChangesAsync();


    }
}
