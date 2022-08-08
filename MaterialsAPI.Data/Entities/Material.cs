namespace MaterialsAPI.Data.Entities
{
    public class Material
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int MaterialTypeId { get; set; }
        public MaterialType MaterialType { get; set; }
        public ICollection<MaterialReview>? Reviews { get; set; }
        public DateTime PublicationDate { get; set; }

    }
}
