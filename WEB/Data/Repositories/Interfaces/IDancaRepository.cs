using System.Linq.Expressions;
using WEB.Models.Entities;

namespace WEB.Data.Repositories.Interfaces
{
    public interface IDancaRepository
    {
        Task AddAsync(Danca result);
        Task<IEnumerable<Danca>> GetAllAsync(Expression<Func<Danca, bool>> expression, Expression<Func<Danca, object>>[] expressions);
        Task<(IEnumerable<Danca> lista, int count)> GetAllPaginationAsync(Expression<Func<Danca, bool>>? expression, int skip);
        Task<Danca?> GetByIdAllIncludesAsync(Guid id, Expression<Func<Danca, bool>>? expression = null);
        Task<Danca> GetByIdAsync(Guid id);
        Task InativarAsync(Guid id);
        Task ReativarAsync(Guid id);
        Task Remover(Danca result);
        Task Update(Danca result);
    }
}
