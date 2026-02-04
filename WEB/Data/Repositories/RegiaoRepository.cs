using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using WEB.Data.Repositories.Interfaces;
using WEB.Models.Entities;

namespace WEB.Data.Repositories
{
    public class RegiaoRepository : IRegiaoRepository
    {
        private readonly DataContext _dataContext;

        public RegiaoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(Regiao model)
        {
            await _dataContext.AddAsync(model);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Regiao>> GetAllAsync(Expression<Func<Regiao, bool>> expression, Expression<Func<Regiao, object>>[] expressions)
        {
            IQueryable<Regiao> query = _dataContext.Regioes.AsNoTracking();

            query = IncludeAllProperties(query);

            if (expressions != null && expressions.Any())
            {
                foreach (var include in expressions)
                {
                    query = query.Include(include);
                }
            }

            var result = expression == null
                ? await query.AsNoTracking().ToListAsync()
                : await query.AsNoTracking().Where(expression).ToListAsync();

            return result;
        }

        public async Task<(IEnumerable<Regiao> lista, int count)> GetAllPaginationAsync(Expression<Func<Regiao, bool>>? expression, int skip)
        {
            var query = _dataContext.Regioes.AsNoTracking();

            query = IncludeAllProperties(query);

            if (expression != null) query = query.Where(expression);

            var lista = await query.OrderBy(x => x.Nome).Skip(skip).Take(5).ToListAsync();
            var count = await query.CountAsync();

            return (lista, count);
        }

        public async Task<Regiao?> GetByIdAllIncludesAsync(Guid id, Expression<Func<Regiao, bool>>? expression = null)
        {
            IQueryable<Regiao> query = _dataContext.Regioes.AsNoTracking();

            query = IncludeAllProperties(query);

            if (expression is not null)
            {
                query = query.Where(expression);
            }

            var result = await query.FirstOrDefaultAsync(e => e.RegiaoId == id);

            return result;
        }

        public async Task<Regiao> GetByIdAsync(Guid regiaoId)
        {
            return await _dataContext.Regioes.FirstOrDefaultAsync(x => x.RegiaoId == regiaoId);
        }

        public async Task Remover(Regiao result)
        {
            _dataContext.Remove(result);
           await _dataContext.SaveChangesAsync();
        }

        public async Task Update(Regiao result)
        {
            _dataContext.Update(result);
            await _dataContext.SaveChangesAsync();
        }

        private IQueryable<Regiao> IncludeAllProperties(IQueryable<Regiao> query)
        {
            return query.Include(e => e.SuperintendenteEstadual).Include(x => x.SuperintendenteRegional);
        }

    }
}
