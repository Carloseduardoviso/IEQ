using System.Linq.Expressions;
using WEB.Models.Entities;

namespace WEB.Data.Repositories.Interfaces
{
    public interface IHomensRepository
    {
        Task AddAsync(Homens result);
        Task<IEnumerable<Homens>> GetAllAsync(Expression<Func<Homens, bool>> expression, Expression<Func<Homens, object>>[] expressions);
        Task<(IEnumerable<Homens> lista, int count)> GetAllPaginationAsync(Expression<Func<Homens, bool>>? expression, int skip);
        Task<Homens?> GetByIdAllIncludesAsync(Guid id, Expression<Func<Homens, bool>>? expression = null);
        Task<Homens> GetByIdAsync(Guid id);
        Task InativarAsync(Guid id);
        Task ReativarAsync(Guid id);
        Task Remover(Homens result);
        Task Update(Homens result);
    }
}
