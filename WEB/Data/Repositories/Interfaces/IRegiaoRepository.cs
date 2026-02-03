using System.Linq.Expressions;
using WEB.Models.Entities;

namespace WEB.Data.Repositories.Interfaces
{
    public interface IRegiaoRepository
    {
        Task AddAsync(Regiao model);
        Task<IEnumerable<Regiao>> GetAllAsync(Expression<Func<Regiao, bool>> expression, Expression<Func<Regiao, object>>[] expressions);
        Task<(IEnumerable<Regiao> lista, int count)> GetAllPaginationAsync(Expression<Func<Regiao, bool>>? expression, int skip);
        Task<Regiao?> GetByIdAllIncludesAsync(Guid id, Expression<Func<Regiao, bool>>? expression = null);

        Task<Regiao> GetByIdAsync(Guid regiaoId);
        Task Remover(Regiao result);
        Task Update(Regiao result);
    }
}
