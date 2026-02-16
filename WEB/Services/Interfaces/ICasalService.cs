using System.Linq.Expressions;
using WEB.Models.ViewModels;

namespace WEB.Services.Interfaces
{
    public interface ICasalService
    {
        Task AddAsync(CasalVm vm);
        Task UpdateAsync(CasalVm vm);
        Task<CasalVm> GetByIdAsync(Guid id);
        Task<CasalVm> Remover(Guid id);
        Task<CasalVm?> GetByIdAllIncludesAsync(Guid id, Expression<Func<CasalVm, bool>>? expression = null);

        Task<IEnumerable<CasalVm>> GetAllAsync(Expression<Func<CasalVm, bool>>? expression = null, params Expression<Func<CasalVm, object?>>[]? includes);
        Task<(IEnumerable<CasalVm> lista, int count)> GetAllPaginationAsync(Expression<Func<CasalVm, bool>>? filtragem, int skip);
        Task InativarAsync(Guid id);
        Task ReativarAsync(Guid id);

    }
}
