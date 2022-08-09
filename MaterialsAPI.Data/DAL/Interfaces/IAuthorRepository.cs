namespace MaterialsAPI.Data.DAL.Interfaces
{
    public interface IAuthorRepository
    {
        Task<ICollection<Author>> GetAll();
    }
}