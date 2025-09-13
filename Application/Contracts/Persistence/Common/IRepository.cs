using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

namespace Application.Contracts.Persistence.common
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<bool> Exists(int id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
