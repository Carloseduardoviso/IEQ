using System.Linq.Expressions;
using WEB.Models.Entities;

namespace WEB.Data.Repositories.Interfaces
{
    public interface ISuperintendenteEstadualRepository
    {
        Task AddAsync(SuperintendenteEstadual result);
        Task<IEnumerable<SuperintendenteEstadual>> GetAllAsync(Expression<Func<SuperintendenteEstadual, bool>> expression, Expression<Func<SuperintendenteEstadual, object>>[] expressions);
        Task<(IEnumerable<SuperintendenteEstadual> lista, int count)> GetAllPaginationAsync(Expression<Func<SuperintendenteEstadual, bool>>? expression, int skip);
        Task<SuperintendenteEstadual?> GetByIdAllIncludesAsync(Guid id, Expression<Func<SuperintendenteEstadual, bool>>? expression = null);

        Task<SuperintendenteEstadual> GetByIdAsync(Guid id);
        Task Remover(SuperintendenteEstadual result);
        Task Update(SuperintendenteEstadual result);
    }
}
