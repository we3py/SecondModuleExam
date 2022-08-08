namespace MaterialsAPI.DTOs.MaterialReview
{
    public class MaterialReviewCreateUpdateDTO
    {
        [Required]
        public int MaterialId { get; set; }
        [Required]
        public string Review { get; set; }
        [Required]
        public int Rating { get; set; }
    }
}
