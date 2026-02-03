
using System.Linq.Expressions;

namespace WEB.Services.Interfaces
{
    public interface IRegiaoService
    {
        Task AddAsync(RegiaoVm vm);
        Task UpdateAsync(RegiaoVm vm); 
        Task<RegiaoVm> GetByIdAsync(Guid regiaoId);
        Task<RegiaoVm> Remover(Guid regiaoId);
        Task<RegiaoVm?> GetByIdAllIncludesAsync(Guid id, Expression<Func<RegiaoVm, bool>>? expression = null);

        Task<IEnumerable<RegiaoVm>> GetAllAsync(Expression<Func<RegiaoVm, bool>>? expression = null, params Expression<Func<RegiaoVm, object?>>[]? includes);
        Task<(IEnumerable<RegiaoVm> lista, int count)> GetAllPaginationAsync(Expression<Func<RegiaoVm, bool>>? filtragem, int skip);
    }
}
