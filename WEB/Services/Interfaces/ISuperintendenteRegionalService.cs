using System.Linq.Expressions;
using WEB.Models.ViewModels;

namespace WEB.Services.Interfaces
{
    public interface ISuperintendenteRegionalService
    {
        Task AddAsync(SuperintendenteRegionalVm vm);
        Task UpdateAsync(SuperintendenteRegionalVm vm);
        Task<SuperintendenteRegionalVm> GetByIdAsync(Guid id);
        Task<SuperintendenteRegionalVm> Remover(Guid id);
        Task<SuperintendenteRegionalVm?> GetByIdAllIncludesAsync(Guid id, Expression<Func<SuperintendenteRegionalVm, bool>>? expression = null);

        Task<IEnumerable<SuperintendenteRegionalVm>> GetAllAsync(Expression<Func<SuperintendenteRegionalVm, bool>>? expression = null, params Expression<Func<SuperintendenteRegionalVm, object?>>[]? includes);
        Task<(IEnumerable<SuperintendenteRegionalVm> lista, int count)> GetAllPaginationAsync(Expression<Func<SuperintendenteRegionalVm, bool>>? filtragem, int skip);
    }
}
