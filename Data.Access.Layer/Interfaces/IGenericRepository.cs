using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Access.Layer.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T item);
        Task<T> GetByIdAsync(string id);
        Task<List<T>> GetAllAsync();
        Task DeleteAsync(string id);
        Task UpdateAsync(T item);
        Task<List<T>> FindAsync(Expression<Func<T, Boolean>> predicate);
        Task<int> GetCountAsync();
    }
}
