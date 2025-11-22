using Microsoft.EntityFrameworkCore;
using MindCareWeb.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindCareWeb.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly MindCareDbContext _ctx;
        protected readonly DbSet<T> _dbSet;
        public GenericRepository(MindCareDbContext ctx)
        {
            _ctx = ctx;
            _dbSet = ctx.Set<T>();
        }

        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);
        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.AsNoTracking().ToListAsync();
        public async Task<T?> GetByIdAsync(object id) => await _dbSet.FindAsync(id);
        public void Remove(T entity) => _dbSet.Remove(entity);
        public void Update(T entity) => _dbSet.Update(entity);
    }
}
