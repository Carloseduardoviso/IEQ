using System.Linq.Expressions;
using WEB.Models.Entities;

namespace WEB.Data.Repositories.Interfaces
{
    public interface ITeatroRepository
    {
        Task AddAsync(Teatro result);
        Task<IEnumerable<Teatro>> GetAllAsync(Expression<Func<Teatro, bool>> expression, Expression<Func<Teatro, object>>[] expressions);
        Task<(IEnumerable<Teatro> lista, int count)> GetAllPaginationAsync(Expression<Func<Teatro, bool>>? expression, int skip);
        Task<Teatro?> GetByIdAllIncludesAsync(Guid id, Expression<Func<Teatro, bool>>? expression = null);
        Task<Teatro> GetByIdAsync(Guid id);
        Task InativarAsync(Guid id);
        Task ReativarAsync(Guid id);
        Task Remover(Teatro result);
        Task Update(Teatro result);
    }
}
