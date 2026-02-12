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

        public Task AddAsync(Teatro result)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Teatro>> GetAllAsync(Expression<Func<Teatro, bool>> expression, Expression<Func<Teatro, object>>[] expressions)
        {
            throw new NotImplementedException();
        }

        public Task<(IEnumerable<Teatro> lista, int count)> GetAllPaginationAsync(Expression<Func<Teatro, bool>>? expression, int skip)
        {
            throw new NotImplementedException();
        }

        public Task<Teatro?> GetByIdAllIncludesAsync(Guid id, Expression<Func<Teatro, bool>>? expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<Teatro> GetByIdAsync(Guid id)
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

        public Task Remover(Teatro result)
        {
            throw new NotImplementedException();
        }

        public Task Update(Teatro result)
        {
            throw new NotImplementedException();
        }
    }
}
