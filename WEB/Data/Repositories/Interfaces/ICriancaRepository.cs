using System.Linq.Expressions;
using WEB.Models.Entities;

namespace WEB.Data.Repositories.Interfaces
{
    public interface ICriancaRepository
    {
        Task AddAsync(Crianca result);
        Task<IEnumerable<Crianca>> GetAllAsync(Expression<Func<Crianca, bool>> expression, Expression<Func<Crianca, object>>[] expressions);
        Task<(IEnumerable<Crianca> lista, int count)> GetAllPaginationAsync(Expression<Func<Crianca, bool>>? expression, int skip);
        Task<Crianca?> GetByIdAllIncludesAsync(Guid id, Expression<Func<Crianca, bool>>? expression = null);
        Task<Crianca> GetByIdAsync(Guid id);
        Task InativarAsync(Guid id);
        Task ReativarAsync(Guid id);
        Task Remover(Crianca result);
        Task Update(Crianca result);
    }
}
