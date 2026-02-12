using System.Linq.Expressions;
using WEB.Data.Repositories.Interfaces;
using WEB.Models.Entities;

namespace WEB.Data.Repositories
{
    public class MidiaRepository : IMidiaRepository
    {
        private readonly DataContext _dataContext;

        public MidiaRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task AddAsync(Midia result)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Midia>> GetAllAsync(Expression<Func<Midia, bool>> expression, Expression<Func<Midia, object>>[] expressions)
        {
            throw new NotImplementedException();
        }

        public Task<(IEnumerable<Midia> lista, int count)> GetAllPaginationAsync(Expression<Func<Midia, bool>>? expression, int skip)
        {
            throw new NotImplementedException();
        }

        public Task<Midia?> GetByIdAllIncludesAsync(Guid id, Expression<Func<Midia, bool>>? expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<Midia> GetByIdAsync(Guid id)
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

        public Task Remover(Midia result)
        {
            throw new NotImplementedException();
        }

        public Task Update(Midia result)
        {
            throw new NotImplementedException();
        }
    }
}
