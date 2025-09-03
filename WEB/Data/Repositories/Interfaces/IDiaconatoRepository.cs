using System.Linq.Expressions;
using WEB.Models.Entities;

namespace WEB.Data.Repositories.Interfaces
{
    public interface IDiaconatoRepository
    {
        Task AddAsync(Diaconato diaconato);
        Task UpdateAsync(Diaconato diaconato);
        Task<Diaconato?> GetByIdAsync(Guid diaconatoId);
        Task<IEnumerable<Diaconato>> GetAllAsync(Expression<Func<Diaconato, bool>>? expression);
    }
}
