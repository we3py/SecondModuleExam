namespace MaterialsAPI.DTOs.Author
{
    public class AuthorCreateUpdateDTO
    {
        [Required]
        public string AuthorName { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
