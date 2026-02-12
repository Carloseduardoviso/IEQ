using System.Linq.Expressions;
using WEB.Models.Entities;

namespace WEB.Data.Repositories.Interfaces
{
    public interface IMidiaRepository
    {
        Task AddAsync(Midia result);
        Task<IEnumerable<Midia>> GetAllAsync(Expression<Func<Midia, bool>> expression, Expression<Func<Midia, object>>[] expressions);
        Task<(IEnumerable<Midia> lista, int count)> GetAllPaginationAsync(Expression<Func<Midia, bool>>? expression, int skip);
        Task<Midia?> GetByIdAllIncludesAsync(Guid id, Expression<Func<Midia, bool>>? expression = null);
        Task<Midia> GetByIdAsync(Guid id);
        Task InativarAsync(Guid id);
        Task ReativarAsync(Guid id);
        Task Remover(Midia result);
        Task Update(Midia result);
    }
}
