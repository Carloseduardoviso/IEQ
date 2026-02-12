using System.Linq.Expressions;
using WEB.Models.Entities;

namespace WEB.Data.Repositories.Interfaces
{
    public interface ILouvorRepository
    {
        Task AddAsync(Louvor result);
        Task<IEnumerable<Louvor>> GetAllAsync(Expression<Func<Louvor, bool>> expression, Expression<Func<Louvor, object>>[] expressions);
        Task<(IEnumerable<Louvor> lista, int count)> GetAllPaginationAsync(Expression<Func<Louvor, bool>>? expression, int skip);
        Task<Louvor?> GetByIdAllIncludesAsync(Guid id, Expression<Func<Louvor, bool>>? expression = null);
        Task<Louvor> GetByIdAsync(Guid id);
        Task InativarAsync(Guid id);
        Task ReativarAsync(Guid id);
        Task Remover(Louvor result);
        Task Update(Louvor result);
    }
}
