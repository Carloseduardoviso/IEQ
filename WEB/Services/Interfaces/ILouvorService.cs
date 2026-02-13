using System.Linq.Expressions;
using WEB.Models.ViewModels;

namespace WEB.Services.Interfaces
{
    public interface ILouvorService
    {
        Task AddAsync(LouvorVm vm);
        Task UpdateAsync(LouvorVm vm);
        Task<LouvorVm> GetByIdAsync(Guid id);
        Task<LouvorVm> Remover(Guid id);
        Task<LouvorVm?> GetByIdAllIncludesAsync(Guid id, Expression<Func<LouvorVm, bool>>? expression = null);

        Task<IEnumerable<LouvorVm>> GetAllAsync(Expression<Func<LouvorVm, bool>>? expression = null, params Expression<Func<LouvorVm, object?>>[]? includes);
        Task<(IEnumerable<LouvorVm> lista, int count)> GetAllPaginationAsync(Expression<Func<LouvorVm, bool>>? filtragem, int skip);
        Task InativarAsync(Guid id);
        Task ReativarAsync(Guid id);

    }
}
