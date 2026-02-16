using System.Linq.Expressions;
using WEB.Models.Entities;

namespace WEB.Data.Repositories.Interfaces
{
    public interface ICasalRepository
    {
        Task AddAsync(Casal result);
        Task<IEnumerable<Casal>> GetAllAsync(Expression<Func<Casal, bool>> expression, Expression<Func<Casal, object>>[] expressions);
        Task<(IEnumerable<Casal> lista, int count)> GetAllPaginationAsync(Expression<Func<Casal, bool>>? expression, int skip);
        Task<Casal?> GetByIdAllIncludesAsync(Guid id, Expression<Func<Casal, bool>>? expression = null);
        Task<Casal> GetByIdAsync(Guid id);
        Task InativarAsync(Guid id);
        Task ReativarAsync(Guid id);
        Task Remover(Casal result);
        Task Update(Casal result);
    }
}
