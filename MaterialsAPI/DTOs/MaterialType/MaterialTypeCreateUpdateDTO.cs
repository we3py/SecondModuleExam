namespace MaterialsAPI.DTOs.MaterialType
{
    public class MaterialTypeCreateUpdateDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Definition { get; set; }
    }
}
