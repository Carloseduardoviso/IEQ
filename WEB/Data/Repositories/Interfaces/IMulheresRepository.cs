using System.Linq.Expressions;
using WEB.Models.Entities;

namespace WEB.Data.Repositories.Interfaces
{
    public interface IMulheresRepository
    {
        Task AddAsync(Mulheres result);
        Task<IEnumerable<Mulheres>> GetAllAsync(Expression<Func<Mulheres, bool>> expression, Expression<Func<Mulheres, object>>[] expressions);
        Task<(IEnumerable<Mulheres> lista, int count)> GetAllPaginationAsync(Expression<Func<Mulheres, bool>>? expression, int skip);
        Task<Mulheres?> GetByIdAllIncludesAsync(Guid id, Expression<Func<Mulheres, bool>>? expression = null);
        Task<Mulheres> GetByIdAsync(Guid id);
        Task InativarAsync(Guid id);
        Task ReativarAsync(Guid id);
        Task Remover(Mulheres result);
        Task Update(Mulheres result);
    }
}
