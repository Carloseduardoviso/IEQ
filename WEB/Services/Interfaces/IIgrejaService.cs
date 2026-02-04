
using System.Linq.Expressions;

namespace WEB.Services.Interfaces
{
    public interface IIgrejaService
    {
        Task AddAsync(IgrejaVm vm);
        Task UpdateAsync(IgrejaVm vm);
        Task<IgrejaVm> GetByIdAsync(Guid igrejaId);
        Task<IgrejaVm> Remover(Guid igrejaId);
        Task<IgrejaVm?> GetByIdAllIncludesAsync(Guid id, Expression<Func<IgrejaVm, bool>>? expression = null);

        Task<IEnumerable<IgrejaVm>> GetAllAsync(Expression<Func<IgrejaVm, bool>>? expression = null, params Expression<Func<IgrejaVm, object?>>[]? includes);
        Task<(IEnumerable<IgrejaVm> lista, int count)> GetAllPaginationAsync(Expression<Func<IgrejaVm, bool>>? filtragem, int skip);
    }
}