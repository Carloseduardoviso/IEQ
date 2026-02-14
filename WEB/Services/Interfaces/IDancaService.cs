using System.Linq.Expressions;
using WEB.Models.ViewModels;

namespace WEB.Services.Interfaces
{
    public interface IDancaService
    {
        Task AddAsync(DancaVm vm);
        Task UpdateAsync(DancaVm vm);
        Task<DancaVm> GetByIdAsync(Guid id);
        Task<DancaVm> Remover(Guid id);
        Task<DancaVm?> GetByIdAllIncludesAsync(Guid id, Expression<Func<DancaVm, bool>>? expression = null);

        Task<IEnumerable<DancaVm>> GetAllAsync(Expression<Func<DancaVm, bool>>? expression = null, params Expression<Func<DancaVm, object?>>[]? includes);
        Task<(IEnumerable<DancaVm> lista, int count)> GetAllPaginationAsync(Expression<Func<DancaVm, bool>>? filtragem, int skip);
        Task InativarAsync(Guid id);
        Task ReativarAsync(Guid id);

    }
}
