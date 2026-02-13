using System.Linq.Expressions;
using WEB.Models.ViewModels;

namespace WEB.Services.Interfaces
{
    public interface IJovemAdolescenteService
    {
        Task AddAsync(JovemAdolescenteVm vm);
        Task UpdateAsync(JovemAdolescenteVm vm);
        Task<JovemAdolescenteVm> GetByIdAsync(Guid id);
        Task<JovemAdolescenteVm> Remover(Guid id);
        Task<JovemAdolescenteVm?> GetByIdAllIncludesAsync(Guid id, Expression<Func<JovemAdolescenteVm, bool>>? expression = null);

        Task<IEnumerable<JovemAdolescenteVm>> GetAllAsync(Expression<Func<JovemAdolescenteVm, bool>>? expression = null, params Expression<Func<JovemAdolescenteVm, object?>>[]? includes);
        Task<(IEnumerable<JovemAdolescenteVm> lista, int count)> GetAllPaginationAsync(Expression<Func<JovemAdolescenteVm, bool>>? filtragem, int skip);
        Task InativarAsync(Guid id);
        Task ReativarAsync(Guid id);
    }
}
