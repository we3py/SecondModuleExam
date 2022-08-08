namespace MaterialsAPI.DTOs.MaterialReview
{
    public class MaterialReviewCreateUpdateDTO
    {
        public int MaterialId { get; set; }
        public string Review { get; set; }
        public int Rating { get; set; }
    }
}
