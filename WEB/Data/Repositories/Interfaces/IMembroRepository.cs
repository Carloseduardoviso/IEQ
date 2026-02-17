using System.Linq.Expressions;
using WEB.Models.Entities;

namespace WEB.Data.Repositories.Interfaces
{
    public interface IMembroRepository
    {
        Task AddAsync(Membro result);
        Task<IEnumerable<Membro>> GetAllAsync(Expression<Func<Membro, bool>> expression, Expression<Func<Membro, object>>[] expressions);
        Task<(IEnumerable<Membro> lista, int count)> GetAllPaginationAsync(Expression<Func<Membro, bool>>? expression, int skip);
        Task<Membro?> GetByIdAllIncludesAsync(Guid id, Expression<Func<Membro, bool>>? expression = null);
        Task<Membro> GetByIdAsync(Guid id);
        Task InativarAsync(Guid id);
        Task ReativarAsync(Guid id);
        Task Remover(Membro result);
        Task Update(Membro result);
    }
}
