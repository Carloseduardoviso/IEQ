using System.Linq.Expressions;
using WEB.Models.Entities;

namespace WEB.Data.Repositories.Interfaces
{
    public interface IPastoresRepository
    {
        Task AddAsync(Pastores result);
        Task<IEnumerable<Pastores>> GetAllAsync(Expression<Func<Pastores, bool>> expression, Expression<Func<Pastores, object>>[] expressions);
        Task<(IEnumerable<Pastores> lista, int count)> GetAllPaginationAsync(Expression<Func<Pastores, bool>>? expression, int skip);
        Task<Pastores?> GetByIdAllIncludesAsync(Guid id, Expression<Func<Pastores, bool>>? expression = null);
        Task<Pastores> GetByIdAsync(Guid id);
        Task InativarAsync(Guid id);
        Task ReativarAsync(Guid id);
        Task Remover(Pastores result);
        Task Update(Pastores result);
    }
}
