namespace MaterialsAPI.Data.DAL.Interfaces
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task<ICollection<Author>> GetAll();
        Task<Author> GetByIdWithMaterialsAndReviews(int id);
    }
}