using System.Linq.Expressions;
using WEB.Models.ViewModels;

namespace WEB.Services.Interfaces
{
    public interface IHomensService
    {
        Task AddAsync(HomensVm vm);
        Task UpdateAsync(HomensVm vm);
        Task<HomensVm> GetByIdAsync(Guid id);
        Task<HomensVm> Remover(Guid id);
        Task<HomensVm?> GetByIdAllIncludesAsync(Guid id, Expression<Func<HomensVm, bool>>? expression = null);

        Task<IEnumerable<HomensVm>> GetAllAsync(Expression<Func<HomensVm, bool>>? expression = null, params Expression<Func<HomensVm, object?>>[]? includes);
        Task<(IEnumerable<HomensVm> lista, int count)> GetAllPaginationAsync(Expression<Func<HomensVm, bool>>? filtragem, int skip);
        Task InativarAsync(Guid id);
        Task ReativarAsync(Guid id);

    }
}
