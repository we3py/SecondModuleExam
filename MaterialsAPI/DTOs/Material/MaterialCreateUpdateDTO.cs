namespace MaterialsAPI.DTOs.Material
{
    public class MaterialCreateUpdateDTO
    {
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public int MaterialTypeId { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "dd/mm/rrrr")]
        public string PublicationDate { get; set; }
    }
}
