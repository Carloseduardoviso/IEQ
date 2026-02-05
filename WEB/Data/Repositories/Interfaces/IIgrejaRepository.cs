using System.Linq.Expressions;
using WEB.Models.Entities;

namespace WEB.Data.Repositories.Interfaces
{
    public interface IIgrejaRepository
    {
        Task AddAsync(Igreja igreja);
        Task<IEnumerable<Igreja>> GetAllAsync(Expression<Func<Igreja, bool>> expression, Expression<Func<Igreja, object>>[] expressions);
        Task<(IEnumerable<Igreja> lista, int count)> GetAllPaginationAsync(Expression<Func<Igreja, bool>>? expression, int skip);
        Task<Igreja?> GetByIdAllIncludesAsync(Guid id, Expression<Func<Igreja, bool>>? expression = null);
        Task<Igreja> GetByIdAsync(Guid igrejaId);
        Task InativarAsync(Guid id);
        Task ReativarAsync(Guid id);
        Task Remover(Igreja result);
        Task Update(Igreja result);
    }
}
