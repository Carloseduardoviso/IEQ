using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using WEB.Data.Repositories.Interfaces;
using WEB.Models.Entities;

namespace WEB.Data.Repositories
{
    public class SuperintendenteEstadualRepository : ISuperintendenteEstadualRepository
    {
        private readonly DataContext _dataContext;

        public SuperintendenteEstadualRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(SuperintendenteEstadual result)
        {
            await _dataContext.AddAsync(result);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<SuperintendenteEstadual>> GetAllAsync(Expression<Func<SuperintendenteEstadual, bool>> expression, Expression<Func<SuperintendenteEstadual, object>>[] expressions)
        {
            IQueryable<SuperintendenteEstadual> query = _dataContext.SuperintendenteEstaduals.AsNoTracking();

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

        public async Task<(IEnumerable<SuperintendenteEstadual> lista, int count)> GetAllPaginationAsync(Expression<Func<SuperintendenteEstadual, bool>>? expression, int skip)
        {
            var query = _dataContext.SuperintendenteEstaduals.AsNoTracking();

            query = IncludeAllProperties(query);

            if (expression != null) query = query.Where(expression);

            var lista = await query.OrderBy(x => x.Nome).Skip(skip).Take(5).ToListAsync();
            var count = await query.CountAsync();

            return (lista, count);
        }

        public async Task<SuperintendenteEstadual?> GetByIdAllIncludesAsync(Guid id, Expression<Func<SuperintendenteEstadual, bool>>? expression = null)
        {
            IQueryable<SuperintendenteEstadual> query = _dataContext.SuperintendenteEstaduals.AsNoTracking();

            query = IncludeAllProperties(query);

            if (expression is not null)
            {
                query = query.Where(expression);
            }

            var result = await query.FirstOrDefaultAsync(e => e.SuperintendenteEstadualId == id);

            return result;
        }

        public async Task<SuperintendenteEstadual> GetByIdAsync(Guid id)
        {
            return await _dataContext.SuperintendenteEstaduals.FirstOrDefaultAsync(x => x.SuperintendenteEstadualId == id);
        }

        public async Task Remover(SuperintendenteEstadual result)
        {
            _dataContext.Remove(result);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Update(SuperintendenteEstadual result)
        {
            _dataContext.Update(result);
            await _dataContext.SaveChangesAsync();
        }

        private IQueryable<SuperintendenteEstadual> IncludeAllProperties(IQueryable<SuperintendenteEstadual> query)
        {
            return query;
        }
    }
}
