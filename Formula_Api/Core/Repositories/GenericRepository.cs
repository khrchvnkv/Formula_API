using Formula_Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Formula_Api.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApiDbContext _context;
        protected readonly ILogger _logger;
        internal readonly DbSet<T> _dbSet;

        public GenericRepository(ApiDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
            _dbSet = _context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAll() => await _dbSet.AsNoTracking().ToListAsync();

        public virtual async Task<T?> GetById(int id) => await _dbSet.FindAsync(id);

        public virtual async Task<bool> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<bool> Update(T entity)
        {
            _dbSet.Update(entity);
            return true;
        }

        public virtual  async Task<bool> Delete(T entity)
        {
            _dbSet.Remove(entity);
            return true;
        }
    }
}