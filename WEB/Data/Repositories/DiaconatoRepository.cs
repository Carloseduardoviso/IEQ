using Microsoft.EntityFrameworkCore;
using WEB.Data.Repositories.Interfaces;
using WEB.Models.Entities;

namespace WEB.Data.Repositories
{
    public class DiaconatoRepository : IDiaconatoRepository
    {
        private readonly DataContext _dataContext;

        public DiaconatoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(Diaconato diaconato)
        {
            await _dataContext.AddAsync(diaconato);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Diaconato?> GetByIdAsync(Guid diaconatoId)
        {
            return await _dataContext.Diaconatos.AsNoTracking().FirstOrDefaultAsync(x => x.DiaconatoId == diaconatoId);
        }

        public async Task UpdateAsync(Diaconato diaconato)
        {
            _dataContext.Diaconatos.Update(diaconato);
            await _dataContext.SaveChangesAsync();
        }
    }
}
