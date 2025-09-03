using System.Linq.Expressions;
using WEB.Models.ViewModels;

namespace WEB.Services.Interfaces
{
    public interface IDiaconatoService
    {
        Task AddAsync(DiaconatoVm diaconatoVm);
        Task UpdateAsync(DiaconatoVm diaconatoVm);
        Task<DiaconatoVm?> GetByIdAsync(Guid diaconatoId);
        Task<IEnumerable<DiaconatoVm>> GetAllAsync(Expression<Func<DiaconatoVm, bool>>? expression = null);
    }
}
