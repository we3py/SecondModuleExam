using MaterialsAPI.Data.Context;
using MaterialsAPI.Data.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialsAPI.Data.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private MaterialsContext _materialsContext;
        public MaterialsContext MaterialContext { get => _materialsContext; }


        public Repository(MaterialsContext materialsContext)
        {
            _materialsContext = materialsContext;
        }

        public async Task AddAsync(T entity)
            => await _materialsContext.Set<T>().AddAsync(entity);

        public void Delete(T entity)
            => _materialsContext.Set<T>().Remove(entity);


        public async Task SaveAsync()
            => await _materialsContext.SaveChangesAsync();


        public void Update(T entity)
            => _materialsContext.Set<T>().Update(entity);

        public async Task<T> GetEntityAsync(int id)
            => await _materialsContext.Set<T>().FindAsync(id)
    }
}
