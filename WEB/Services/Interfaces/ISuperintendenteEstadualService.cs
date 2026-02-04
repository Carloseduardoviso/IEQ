using System.Linq.Expressions;
using WEB.Models.ViewModels;

namespace WEB.Services.Interfaces
{
    public interface ISuperintendenteEstadualService
    {
        Task AddAsync(SuperintendenteEstadualVm result);
        Task UpdateAsync(SuperintendenteEstadualVm vm);
        Task<SuperintendenteEstadualVm?> GetByIdAllIncludesAsync(Guid id, Expression<Func<SuperintendenteEstadualVm, bool>>? expression = null);
        Task<IEnumerable<SuperintendenteEstadualVm>> GetAllAsync(Expression<Func<SuperintendenteEstadualVm, bool>>? expression = null, params Expression<Func<SuperintendenteEstadualVm, object?>>[]? includes);
        Task<(IEnumerable<SuperintendenteEstadualVm> lista, int count)> GetAllPaginationAsync(Expression<Func<SuperintendenteEstadualVm, bool>>? filtragem, int skip);
        Task<SuperintendenteEstadualVm> GetByIdAsync(Guid id);
        Task<SuperintendenteEstadualVm> Remover(Guid id);
    }
}
