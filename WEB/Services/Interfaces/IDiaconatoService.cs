using WEB.Models.ViewModels;

namespace WEB.Services.Interfaces
{
    public interface IDiaconatoService
    {
        Task AddAsync(DiaconatoVm diaconatoVm);
        Task UpdateAsync(DiaconatoVm diaconatoVm);
        Task<DiaconatoVm?> GetByIdAsync(Guid diaconatoId);
    }
}
