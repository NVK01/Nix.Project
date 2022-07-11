using Data.Access.Layer.EF;
using Data.Access.Layer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Access.Layer.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(ApplicationDbContext applicationDbContext)
        {

            _applicationDbContext = applicationDbContext;
            _dbSet = applicationDbContext.Set<T>();
        }

        public async Task<T> AddAsync(T item)
        {
            _dbSet.Attach(item);
            var created = await _dbSet.AddAsync(item);
            await _applicationDbContext.SaveChangesAsync();
            return created.Entity;
        }

        public async Task DeleteAsync(string id)
        {
            var item = await _dbSet.FindAsync(id);
            _=_dbSet.Remove(item);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<int> GetCountAsync()
        {
            return await _dbSet.CountAsync();
        }

        public async Task UpdateAsync(T item)
        {
            _applicationDbContext.Attach(item);
            _applicationDbContext.Update(item);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
