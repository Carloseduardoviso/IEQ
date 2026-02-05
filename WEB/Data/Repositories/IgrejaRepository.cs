using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using WEB.Data.Repositories.Interfaces;
using WEB.Models.Entities;

namespace WEB.Data.Repositories
{
    public class IgrejaRepository : IIgrejaRepository
    {
        private readonly DataContext _dataContext;

        public IgrejaRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(Igreja igreja)
        {
            await _dataContext.AddAsync(igreja);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Igreja>> GetAllAsync(Expression<Func<Igreja, bool>> expression, Expression<Func<Igreja, object>>[] expressions)
        {
            IQueryable<Igreja> query = _dataContext.Igrejas.AsNoTracking();

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

        public async Task<(IEnumerable<Igreja> lista, int count)> GetAllPaginationAsync(Expression<Func<Igreja, bool>>? expression, int skip)
        {
            var query = _dataContext.Igrejas.AsNoTracking();

            query = IncludeAllProperties(query);

            if (expression != null) query = query.Where(expression);

            var lista = await query.OrderBy(x => x.Nome).Skip(skip).Take(5).ToListAsync();
            var count = await query.CountAsync();

            return (lista, count);
        }

        public async Task<Igreja?> GetByIdAllIncludesAsync(Guid id, Expression<Func<Igreja, bool>>? expression = null)
        {
            IQueryable<Igreja> query = _dataContext.Igrejas.AsNoTracking();

            query = IncludeAllProperties(query);

            if (expression is not null)
            {
                query = query.Where(expression);
            }

            var result = await query.FirstOrDefaultAsync(e => e.IgrejaId == id);

            return result;
        }

        public async Task<Igreja> GetByIdAsync(Guid igrejaId)
        {
            return await _dataContext.Igrejas.FirstOrDefaultAsync(x => x.IgrejaId == igrejaId);
        }

        public async Task InativarAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);

            if (entity != null)
            {
                entity.Ativo = false;
                _dataContext.Igrejas.Update(entity);
                await _dataContext.SaveChangesAsync();
            }
        }

        public async Task ReativarAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);

            if (entity != null)
            {
                entity.Ativo = true;
                _dataContext.Igrejas.Update(entity);
                await _dataContext.SaveChangesAsync();
            }
        }

        public async Task Remover(Igreja result)
        {
            _dataContext.Remove(result);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Update(Igreja result)
        {
            _dataContext.Update(result);
            await _dataContext.SaveChangesAsync();
        }

        private IQueryable<Igreja> IncludeAllProperties(IQueryable<Igreja> query)
        {
            return query.Include(x => x.Regiao);
        }
    }
}