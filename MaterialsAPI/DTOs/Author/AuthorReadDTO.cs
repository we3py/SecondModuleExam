using MaterialsAPI.DTOs.Material;

namespace MaterialsAPI.DTOs.Author
{
    public class AuthorReadDTO
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
        public ICollection<MaterialReadDTO> Materials { get; set; }
        public int MaterialAmount { get; set; }
    }
}
