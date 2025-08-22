using System.Linq.Expressions;

namespace WEB.Data.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        Task<TEntity?> GetByIdAsync(Guid id);
        Task<TEntity?> GetFirstAsync(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object?>>[]? includes);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null, params Expression<Func<TEntity, object>>[]? includes);

    }
}
