namespace MaterialsAPI.Data.DAL.Interfaces
{
    public interface IMaterialReviewRepository : IRepository<MaterialReview>
    {
        Task<ICollection<MaterialReview>> GetAll();
        Task<MaterialReview> GetById(int id);
    }
}