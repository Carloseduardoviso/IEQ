using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using WEB.Data.Repositories.Interfaces;
using WEB.Models.Entities;

namespace WEB.Data.Repositories
{
    public class PastoresRepository : IPastoresRepository
    {
        private readonly DataContext _dataContext;

        public PastoresRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(Pastores result)
        {
            await _dataContext.AddAsync(result);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Pastores>> GetAllAsync(Expression<Func<Pastores, bool>> expression, Expression<Func<Pastores, object>>[] expressions)
        {
            IQueryable<Pastores> query = _dataContext.Pastores.AsNoTracking();

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

        public async Task<(IEnumerable<Pastores> lista, int count)> GetAllPaginationAsync(Expression<Func<Pastores, bool>>? expression, int skip)
        {
            var query = _dataContext.Pastores.AsNoTracking();

            query = IncludeAllProperties(query);

            if (expression != null) query = query.Where(expression);

            var lista = await query.OrderBy(x => x.Nome).Skip(skip).Take(5).ToListAsync();
            var count = await query.CountAsync();

            return (lista, count);
        }

        public async Task<Pastores?> GetByIdAllIncludesAsync(Guid id, Expression<Func<Pastores, bool>>? expression = null)
        {
            IQueryable<Pastores> query = _dataContext.Pastores.AsNoTracking();

            query = IncludeAllProperties(query);

            if (expression is not null)
            {
                query = query.Where(expression);
            }

            var result = await query.FirstOrDefaultAsync(e => e.PastorId == id);

            return result;
        }

        public async Task<Pastores> GetByIdAsync(Guid id)
        {
            return await _dataContext.Pastores.FirstOrDefaultAsync(x => x.PastorId == id);
        }

        public async Task InativarAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);

            if (entity != null)
            {
                entity.Ativo = false;
                _dataContext.Pastores.Update(entity);
                await _dataContext.SaveChangesAsync();
            }
        }

        public async Task ReativarAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);

            if (entity != null)
            {
                entity.Ativo = true;
                _dataContext.Pastores.Update(entity);
                await _dataContext.SaveChangesAsync();
            }
        }

        public async Task Remover(Pastores result)
        {
            _dataContext.Remove(result);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Update(Pastores result)
        {
            _dataContext.Update(result);
            await _dataContext.SaveChangesAsync();
        }

        private IQueryable<Pastores> IncludeAllProperties(IQueryable<Pastores> query)
        {
            return query.Include(x => x.Igreja).ThenInclude(x => x.Regiao);
        }

    }
}
