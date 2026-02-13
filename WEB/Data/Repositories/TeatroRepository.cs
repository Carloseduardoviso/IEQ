using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using WEB.Data.Repositories.Interfaces;
using WEB.Models.Entities;

namespace WEB.Data.Repositories
{
    public class TeatroRepository : ITeatroRepository
    {
        private readonly DataContext _dataContext;

        public TeatroRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(Teatro result)
        {
            await _dataContext.AddAsync(result);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Teatro>> GetAllAsync(Expression<Func<Teatro, bool>> expression, Expression<Func<Teatro, object>>[] expressions)
        {
            IQueryable<Teatro> query = _dataContext.Teatros.AsNoTracking();

            query = IncludeAllProperties(query);

            if (expression is not null)
                query = query.Where(expression);

            return await query
                .OrderBy(c => c.NomeCompleto)
                .ToListAsync();
        }

        public async Task<(IEnumerable<Teatro> lista, int count)> GetAllPaginationAsync(Expression<Func<Teatro, bool>>? expression, int skip)
        {
            var query = _dataContext.Teatros.AsNoTracking();
            query = IncludeAllProperties(query);

            if (expression != null) query = query.Where(expression);
            var lista = await query.Where(x => x.Ativo).OrderBy(x => x.NomeCompleto).Skip(skip).Take(5).ToListAsync();
            var count = await query.CountAsync();

            return (lista, count);
        }

        public async Task<Teatro?> GetByIdAllIncludesAsync(Guid id, Expression<Func<Teatro, bool>>? expression = null)
        {
            IQueryable<Teatro> query = _dataContext.Teatros.AsNoTracking();

            query = IncludeAllProperties(query);

            if (expression is not null)
            {
                query = query.Where(expression);
            }

            var result = await query.FirstOrDefaultAsync(e => e.TeatroId == id);

            return result;
        }

        public async Task<Teatro> GetByIdAsync(Guid id)
        {
            return await IncludeAllProperties(_dataContext.Teatros)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.TeatroId == id);
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
                _dataContext.Teatros.Update(entity);
                await _dataContext.SaveChangesAsync();
            }
        }

        public Task Remover(Teatro result)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Teatro result)
        {
            _dataContext.Teatros.Update(result);
            await _dataContext.SaveChangesAsync();
        }

        private IQueryable<Teatro> IncludeAllProperties(IQueryable<Teatro> query)
        {
            return query.Include(x => x.Igreja).Include(x => x.Regiao).Include(x => x.Pastor).Include(x => x.SuperintendenteRegional).Include(x => x.SuperintendenteEstadual);
        }

    }
}
