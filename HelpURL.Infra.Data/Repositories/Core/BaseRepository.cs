using HelpURL.Domain.Core.Entities;
using HelpURL.Domain.Core.Interfaces;
using HelpURL.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace HelpURL.Infra.Data.Repositories.Core
{
    public  class BaseRepository<T> : IBaseRepository<T> where T : Entity
    {
        protected readonly HelpURLContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(HelpURLContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<bool> Delete(T entity)
        {
            await Task.Run(() => _dbSet.Remove(entity));
            return true;
        }
        public virtual async Task<IEnumerable<T>> GetAll()
          => await _dbSet.AsNoTracking().ToListAsync();

        public virtual async Task<T> GetOneWhere(System.Linq.Expressions.Expression<Func<T, bool>> condition)
=> (await _dbSet.AsNoTracking().FirstOrDefaultAsync(condition))!;


        public async Task<T> Insert(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            await Task.Run(() => _dbSet.Update(entity));
            return entity;
        }
    }
}
