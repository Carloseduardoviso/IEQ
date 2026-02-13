using System.Linq.Expressions;
using WEB.Models.ViewModels;

namespace WEB.Services.Interfaces
{
    public interface ITeatroService
    {
        Task AddAsync(TeatroVm vm);
        Task UpdateAsync(TeatroVm vm);
        Task<TeatroVm> GetByIdAsync(Guid id);
        Task<TeatroVm> Remover(Guid id);
        Task<TeatroVm?> GetByIdAllIncludesAsync(Guid id, Expression<Func<TeatroVm, bool>>? expression = null);

        Task<IEnumerable<TeatroVm>> GetAllAsync(Expression<Func<TeatroVm, bool>>? expression = null, params Expression<Func<TeatroVm, object?>>[]? includes);
        Task<(IEnumerable<TeatroVm> lista, int count)> GetAllPaginationAsync(Expression<Func<TeatroVm, bool>>? filtragem, int skip);
        Task InativarAsync(Guid id);
        Task ReativarAsync(Guid id);

    }
}
