using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<IEnumerable<Diaconato>> GetAllAsync(Expression<Func<Diaconato, bool>>? expression)
        {
            IQueryable<Diaconato> query = _dataContext.Diaconatos.AsNoTracking();

            // aplica includes
            query = IncludeAllProperties(query);

            if (expression is not null)
                query = query.Where(expression);

            return await query
                .OrderBy(c => c.NomeCompleto)
                .ToListAsync();
        }

        public async Task<(IEnumerable<Diaconato> lista, int count)> GetAllPaginationAsync(Expression<Func<Diaconato, bool>>? expression, int skip)
        {
            var query = _dataContext.Diaconatos.AsNoTracking();
            query = IncludeAllProperties(query);

            if (expression != null) query = query.Where(expression);
            var lista = await query.Where(x => x.Ativo).OrderBy(x => x.NomeCompleto).Skip(skip).Take(5).ToListAsync();
            var count = await query.CountAsync();

            return (lista, count);
        }

        public async Task<Diaconato?> GetByIdAsync(Guid diaconatoId)
        {
            return await IncludeAllProperties(_dataContext.Diaconatos)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.DiaconatoId == diaconatoId);
        }

        public async Task InativarAsync(Guid diaconatoId)
        {
            var item = await GetByIdAsync(diaconatoId);

            item.Ativo = false;
            item.DataInativacao = DateTime.Today;

            // Se nunca foi reativado antes, usa DataMinisterio como início
            var inicio = item.DataReativacao ?? item.DataMinisterio;

            if (inicio == null)
                throw new Exception("DataMinisterio não pode ser nula.");

            var fim = DateTime.Today;

            int meses = ((fim.Year - inicio.Value.Year) * 12) + fim.Month - inicio.Value.Month;

            if (fim.Day < inicio.Value.Day)
                meses--;

            item.TempoAcumuladoEmMeses += Math.Max(0, meses);

            // Zera início para o próximo ciclo
            item.DataReativacao = null;

            await UpdateAsync(item);
        }


        public async Task ReativarAsync(Guid diaconatoId)
        {
            var entity = await GetByIdAsync(diaconatoId);

            if (entity != null)
            {
                entity.Ativo = true;
                entity.DataReativacao = DateTime.Today;
                _dataContext.Diaconatos.Update(entity);
                await _dataContext.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Diaconato diaconato)
        {
            _dataContext.Diaconatos.Update(diaconato);
            await _dataContext.SaveChangesAsync();
        }

        private IQueryable<Diaconato> IncludeAllProperties(IQueryable<Diaconato> query)
        {
            return query.Include(x => x.Igreja).Include(x => x.Regiao).Include(x => x.Pastor).Include(x => x.SuperintendenteRegional).Include(x => x.SuperintendenteEstadual);
        }
    }
}
