using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MongoRepositoryPattern.Repositories
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> condition);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> condition);
        Task<TEntity> FirstOrDefaultAsync(string id);
        Task<IReadOnlyList<TEntity>> ToListAsync();
        Task<IReadOnlyList<TEntity>> ToListAsync(Expression<Func<TEntity, bool>> condition);
        Task AddAsync(TEntity entity);
        Task Remove(TEntity entity);
        Task Remove(Expression<Func<TEntity, bool>> condition);
        Task Remove(string id);
        Task UpdateAsync(TEntity entity);
        Task UpdateAsync(Expression<Func<TEntity, bool>> expression, TEntity entity);

    }
}
