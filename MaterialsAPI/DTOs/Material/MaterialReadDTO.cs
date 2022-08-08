using MaterialsAPI.DTOs.MaterialReview;

namespace MaterialsAPI.DTOs.Material
{
    public class MaterialReadDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string MaterialTypeName { get; set; }
        public ICollection<MaterialReviewReadDTO> Reviews { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
