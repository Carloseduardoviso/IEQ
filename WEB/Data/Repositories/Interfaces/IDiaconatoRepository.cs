using WEB.Models.Entities;

namespace WEB.Data.Repositories.Interfaces
{
    public interface IDiaconatoRepository
    {
        Task AddAsync(Diaconato diaconato);
        Task UpdateAsync(Diaconato diaconato);
        Task<Diaconato?> GetByIdAsync(Guid diaconatoId);
    }
}
