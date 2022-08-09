namespace MaterialsAPI.DTOs.MaterialReview
{
    public class MaterialReviewCreateUpdateDTO
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int MaterialId { get; set; }
        [Required]
        [MaxLength(150)]
        public string Review { get; set; }
        [Required]
        [Range(0, 10, ErrorMessage = "Choose number from scale 0-10")]
        public int Rating { get; set; }
    }
}
