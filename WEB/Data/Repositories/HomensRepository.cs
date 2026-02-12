using Microsoft.EntityFrameworkCore;
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

        public Task AddAsync(Homens result)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Homens>> GetAllAsync(Expression<Func<Homens, bool>> expression, Expression<Func<Homens, object>>[] expressions)
        {
            throw new NotImplementedException();
        }

        public Task<(IEnumerable<Homens> lista, int count)> GetAllPaginationAsync(Expression<Func<Homens, bool>>? expression, int skip)
        {
            throw new NotImplementedException();
        }

        public Task<Homens?> GetByIdAllIncludesAsync(Guid id, Expression<Func<Homens, bool>>? expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<Homens> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task InativarAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task ReativarAsync(Guid id)
        {
            throw new NotImplementedException();
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
