using System.Linq.Expressions;
using WEB.Models.ViewModels;

namespace WEB.Services.Interfaces
{
    public interface IMembroService
    {
        Task AddAsync(MembroVm vm);
        Task UpdateAsync(MembroVm vm);
        Task<MembroVm> GetByIdAsync(Guid id);
        Task<MembroVm> Remover(Guid id);
        Task<MembroVm?> GetByIdAllIncludesAsync(Guid id, Expression<Func<MembroVm, bool>>? expression = null);

        Task<IEnumerable<MembroVm>> GetAllAsync(Expression<Func<MembroVm, bool>>? expression = null, params Expression<Func<MembroVm, object?>>[]? includes);
        Task<(IEnumerable<MembroVm> lista, int count)> GetAllPaginationAsync(Expression<Func<MembroVm, bool>>? filtragem, int skip);
        Task InativarAsync(Guid id);
        Task ReativarAsync(Guid id);

    }
}
