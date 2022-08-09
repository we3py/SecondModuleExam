namespace MaterialsAPI.DTOs.MaterialType
{
    public class MaterialTypeCreateUpdateDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Definition { get; set; }
    }
}
