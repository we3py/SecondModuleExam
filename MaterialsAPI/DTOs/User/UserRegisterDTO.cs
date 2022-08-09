namespace MaterialsAPI.DTOs.User
{
    public class UserRegisterDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
