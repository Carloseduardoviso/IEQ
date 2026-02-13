using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WEB.Data.Repositories.Interfaces;
using WEB.Models.Entities;

namespace WEB.Data.Repositories
{
    public class LouvorRepository : ILouvorRepository
    {
        private readonly DataContext _dataContext;

        public LouvorRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(Louvor result)
        {
            await _dataContext.AddAsync(result);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Louvor>> GetAllAsync(Expression<Func<Louvor, bool>> expression, Expression<Func<Louvor, object>>[] expressions)
        {
            IQueryable<Louvor> query = _dataContext.Louvores.AsNoTracking();

            query = IncludeAllProperties(query);

            if (expression is not null)
                query = query.Where(expression);

            return await query
                .OrderBy(c => c.NomeCompleto)
                .ToListAsync();
        }

        public async Task<(IEnumerable<Louvor> lista, int count)> GetAllPaginationAsync(Expression<Func<Louvor, bool>>? expression, int skip)
        {
            var query = _dataContext.Louvores.AsNoTracking();
            query = IncludeAllProperties(query);

            if (expression != null) query = query.Where(expression);
            var lista = await query.Where(x => x.Ativo).OrderBy(x => x.NomeCompleto).Skip(skip).Take(5).ToListAsync();
            var count = await query.CountAsync();

            return (lista, count);
        }

        public async Task<Louvor?> GetByIdAllIncludesAsync(Guid id, Expression<Func<Louvor, bool>>? expression = null)
        {
            IQueryable<Louvor> query = _dataContext.Louvores.AsNoTracking();

            query = IncludeAllProperties(query);

            if (expression is not null)
            {
                query = query.Where(expression);
            }

            var result = await query.FirstOrDefaultAsync(e => e.LouvorId == id);

            return result;
        }

        public async Task<Louvor> GetByIdAsync(Guid id)
        {
            return await IncludeAllProperties(_dataContext.Louvores)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.LouvorId == id);
        }

        public async Task InativarAsync(Guid id)
        {
            var item = await GetByIdAsync(id);

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

            await Update(item);
        }

        public async Task ReativarAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);

            if (entity != null)
            {
                entity.Ativo = true;
                entity.DataReativacao = DateTime.Today;
                _dataContext.Louvores.Update(entity);
                await _dataContext.SaveChangesAsync();
            }
        }

        public async Task Remover(Louvor result)
        {
            _dataContext.Louvores.Update(result);
            await _dataContext.SaveChangesAsync();
        }

        public Task Update(Louvor result)
        {
            throw new NotImplementedException();
        }

        private IQueryable<Louvor> IncludeAllProperties(IQueryable<Louvor> query)
        {
            return query.Include(x => x.Igreja).Include(x => x.Regiao).Include(x => x.Pastor).Include(x => x.SuperintendenteRegional).Include(x => x.SuperintendenteEstadual);
        }
    }
}
