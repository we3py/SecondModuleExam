namespace MaterialsAPI.DTOs.Material
{
    public class MaterialCreateUpdateDTO
    {
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int MaterialTypeId { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
