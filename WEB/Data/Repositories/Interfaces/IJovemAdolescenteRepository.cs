using System.Linq.Expressions;
using WEB.Models.Entities;

namespace WEB.Data.Repositories.Interfaces
{
    public interface IJovemAdolescenteRepository
    {
        Task AddAsync(JovemAdolescente result);
        Task<IEnumerable<JovemAdolescente>> GetAllAsync(Expression<Func<JovemAdolescente, bool>> expression, Expression<Func<JovemAdolescente, object>>[] expressions);
        Task<(IEnumerable<JovemAdolescente> lista, int count)> GetAllPaginationAsync(Expression<Func<JovemAdolescente, bool>>? expression, int skip);
        Task<JovemAdolescente?> GetByIdAllIncludesAsync(Guid id, Expression<Func<JovemAdolescente, bool>>? expression = null);
        Task<JovemAdolescente> GetByIdAsync(Guid id);
        Task InativarAsync(Guid id);
        Task ReativarAsync(Guid id);
        Task Remover(JovemAdolescente result);
        Task Update(JovemAdolescente result);
    }
}
