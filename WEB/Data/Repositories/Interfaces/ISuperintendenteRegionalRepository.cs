using System.Linq.Expressions;
using WEB.Models.Entities;

namespace WEB.Data.Repositories.Interfaces
{
    public interface ISuperintendenteRegionalRepository
    {
        Task AddAsync(SuperintendenteRegional result);
        Task<IEnumerable<SuperintendenteRegional>> GetAllAsync(Expression<Func<SuperintendenteRegional, bool>> expression, Expression<Func<SuperintendenteRegional, object>>[] expressions);
        Task<(IEnumerable<SuperintendenteRegional> lista, int count)> GetAllPaginationAsync(Expression<Func<SuperintendenteRegional, bool>>? expression, int skip);
        Task<SuperintendenteRegional?> GetByIdAllIncludesAsync(Guid id, Expression<Func<SuperintendenteRegional, bool>>? expression = null);
        Task<SuperintendenteRegional> GetByIdAsync(Guid id);
        Task Remover(SuperintendenteRegional result);
        Task Update(SuperintendenteRegional result);
    }
}
