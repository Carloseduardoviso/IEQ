using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq;
using System.Linq.Expressions;
using WEB.Data.Repositories.Interfaces;
using WEB.Models.Entities;

namespace WEB.Data.Repositories
{
    public class SuperintendenteRegionalRepository : ISuperintendenteRegionalRepository
    {
        private readonly DataContext _dataContext;

        public SuperintendenteRegionalRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(SuperintendenteRegional result)
        {
            await _dataContext.AddAsync(result);
            await _dataContext.SaveChangesAsync();
        }           


        public async Task Remover(SuperintendenteRegional result)
        {
            _dataContext.Remove(result);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Update(SuperintendenteRegional result)
        {
            _dataContext.Update(result);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<SuperintendenteRegional>> GetAllAsync(Expression<Func<SuperintendenteRegional, bool>> expression, Expression<Func<SuperintendenteRegional, object>>[] expressions)
        {
            IQueryable<SuperintendenteRegional> query = _dataContext.SuperintendenteRegionals.AsNoTracking();

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

        public async Task<(IEnumerable<SuperintendenteRegional> lista, int count)> GetAllPaginationAsync(Expression<Func<SuperintendenteRegional, bool>>? expression, int skip)
        {
            var query = _dataContext.SuperintendenteRegionals.AsNoTracking();

            query = IncludeAllProperties(query);

            if (expression != null) query = query.Where(expression);

            var lista = await query.OrderBy(x => x.Nome).Skip(skip).Take(5).ToListAsync();
            var count = await query.CountAsync();

            return (lista, count);
        }

        public async Task<SuperintendenteRegional?> GetByIdAllIncludesAsync(Guid id, Expression<Func<SuperintendenteRegional, bool>>? expression)
        {
            IQueryable<SuperintendenteRegional> query = _dataContext.SuperintendenteRegionals.AsNoTracking();

            query = IncludeAllProperties(query);

            if (expression is not null)
            {
                query = query.Where(expression);
            }

            var result = await query.FirstOrDefaultAsync(e => e.SuperintendenteRegionalId == id);

            return result;
        }

        public async Task<SuperintendenteRegional> GetByIdAsync(Guid id)
        {
            return await _dataContext.SuperintendenteRegionals.FirstOrDefaultAsync(x => x.SuperintendenteRegionalId == id);
        }

        private IQueryable<SuperintendenteRegional> IncludeAllProperties(IQueryable<SuperintendenteRegional> query)
        {
            return query;
        }
    }
}
