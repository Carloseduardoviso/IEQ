using System.Linq.Expressions;
using WEB.Models.ViewModels;

namespace WEB.Services.Interfaces
{
    public interface IMidiaService
    {
        Task AddAsync(MidiaVm vm);
        Task UpdateAsync(MidiaVm vm);
        Task<MidiaVm> GetByIdAsync(Guid id);
        Task<MidiaVm> Remover(Guid id);
        Task<MidiaVm?> GetByIdAllIncludesAsync(Guid id, Expression<Func<MidiaVm, bool>>? expression = null);

        Task<IEnumerable<MidiaVm>> GetAllAsync(Expression<Func<MidiaVm, bool>>? expression = null, params Expression<Func<MidiaVm, object?>>[]? includes);
        Task<(IEnumerable<MidiaVm> lista, int count)> GetAllPaginationAsync(Expression<Func<MidiaVm, bool>>? filtragem, int skip);
        Task InativarAsync(Guid id);
        Task ReativarAsync(Guid id);

    }
}
