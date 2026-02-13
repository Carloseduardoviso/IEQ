using System.Linq.Expressions;
using WEB.Models.ViewModels;

namespace WEB.Services.Interfaces
{
    public interface IMulheresService
    {
        Task AddAsync(MulheresVm vm);
        Task UpdateAsync(MulheresVm vm);
        Task<MulheresVm> GetByIdAsync(Guid id);
        Task<MulheresVm> Remover(Guid id);
        Task<MulheresVm?> GetByIdAllIncludesAsync(Guid id, Expression<Func<MulheresVm, bool>>? expression = null);

        Task<IEnumerable<MulheresVm>> GetAllAsync(Expression<Func<MulheresVm, bool>>? expression = null, params Expression<Func<MulheresVm, object?>>[]? includes);
        Task<(IEnumerable<MulheresVm> lista, int count)> GetAllPaginationAsync(Expression<Func<MulheresVm, bool>>? filtragem, int skip);
        Task InativarAsync(Guid id);
        Task ReativarAsync(Guid id);

    }
}
