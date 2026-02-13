using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using WEB.Data.Repositories.Interfaces;
using WEB.Models.Entities;

namespace WEB.Data.Repositories
{
    public class HomensRepository : IHomensRepository
    {
        private readonly DataContext _dataContext;

        public HomensRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(Homens result)
        {
            await _dataContext.AddAsync(result);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Homens>> GetAllAsync(Expression<Func<Homens, bool>> expression, Expression<Func<Homens, object>>[] expressions)
        {
            IQueryable<Homens> query = _dataContext.Homens.AsNoTracking();

            query = IncludeAllProperties(query);

            if (expression is not null)
                query = query.Where(expression);

            return await query
                .OrderBy(c => c.NomeCompleto)
                .ToListAsync();
        }

        public async Task<(IEnumerable<Homens> lista, int count)> GetAllPaginationAsync(Expression<Func<Homens, bool>>? expression, int skip)
        {
            var query = _dataContext.Homens.AsNoTracking();
            query = IncludeAllProperties(query);

            if (expression != null) query = query.Where(expression);
            var lista = await query.Where(x => x.Ativo).OrderBy(x => x.NomeCompleto).Skip(skip).Take(5).ToListAsync();
            var count = await query.CountAsync();

            return (lista, count);
        }

        public async Task<Homens?> GetByIdAllIncludesAsync(Guid id, Expression<Func<Homens, bool>>? expression = null)
        {
            IQueryable<Homens> query = _dataContext.Homens.AsNoTracking();

            query = IncludeAllProperties(query);

            if (expression is not null)
            {
                query = query.Where(expression);
            }

            var result = await query.FirstOrDefaultAsync(e => e.HomensId == id);

            return result;
        }

        public async Task<Homens> GetByIdAsync(Guid id)
        {
            return await IncludeAllProperties(_dataContext.Homens)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.HomensId == id);
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
                _dataContext.Homens.Update(entity);
                await _dataContext.SaveChangesAsync();
            }
        }

        public Task Remover(Homens result)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Homens result)
        {
            _dataContext.Homens.Update(result);
            await _dataContext.SaveChangesAsync();
        }

        private IQueryable<Homens> IncludeAllProperties(IQueryable<Homens> query)
        {
            return query.Include(x => x.Igreja).Include(x => x.Regiao).Include(x => x.Pastor).Include(x => x.SuperintendenteRegional).Include(x => x.SuperintendenteEstadual);
        }
    }
}
