namespace MaterialsAPI.Data.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task<T> GetEntityAsync(int id);
        void Update(T entity);
        void Delete(T entity);
        Task SaveAsync();
    }
}
