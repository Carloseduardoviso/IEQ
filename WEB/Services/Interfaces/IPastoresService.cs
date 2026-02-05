

using System.Linq.Expressions;

namespace WEB.Services.Interfaces
{
    public interface IPastoresService
    {
        Task AddAsync(PastoresVm vm);
        Task UpdateAsync(PastoresVm vm);
        Task<PastoresVm> GetByIdAsync(Guid id);
        Task<PastoresVm> Remover(Guid id);
        Task<PastoresVm?> GetByIdAllIncludesAsync(Guid id, Expression<Func<PastoresVm, bool>>? expression = null);

        Task<IEnumerable<PastoresVm>> GetAllAsync(Expression<Func<PastoresVm, bool>>? expression = null, params Expression<Func<PastoresVm, object?>>[]? includes);
        Task<(IEnumerable<PastoresVm> lista, int count)> GetAllPaginationAsync(Expression<Func<PastoresVm, bool>>? filtragem, int skip);
        Task InativarAsync(Guid id);
        Task ReativarAsync(Guid id);

    }
}
