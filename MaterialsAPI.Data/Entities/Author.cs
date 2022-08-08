namespace MaterialsAPI.Data.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
        public ICollection<Material> Materials { get; set; }
        public int MaterialAmount { get { return Materials.Count; } }
    }
}
