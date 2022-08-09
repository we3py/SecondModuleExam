namespace MaterialsAPI.DTOs.Material
{
    public class MaterialCreateUpdateDTO
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int AuthorId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(150)]
        public string Description { get; set; }
        [Required]
        [MaxLength(100)]
        public string Location { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int MaterialTypeId { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public string PublicationDate { get; set; }
    }
}
