namespace MaterialsAPI.DTOs.User
{
    public class UserLoginRegisterDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
