using System.Linq.Expressions;
using WEB.Models.ViewModels;

namespace WEB.Services.Interfaces
{
    public interface ICriancaService
    {
        Task AddAsync(CriancaVm vm);
        Task UpdateAsync(CriancaVm vm);
        Task<CriancaVm> GetByIdAsync(Guid id);
        Task<CriancaVm> Remover(Guid id);
        Task<CriancaVm?> GetByIdAllIncludesAsync(Guid id, Expression<Func<CriancaVm, bool>>? expression = null);

        Task<IEnumerable<CriancaVm>> GetAllAsync(Expression<Func<CriancaVm, bool>>? expression = null, params Expression<Func<CriancaVm, object?>>[]? includes);
        Task<(IEnumerable<CriancaVm> lista, int count)> GetAllPaginationAsync(Expression<Func<CriancaVm, bool>>? filtragem, int skip);
        Task InativarAsync(Guid id);
        Task ReativarAsync(Guid id);

    }
}
