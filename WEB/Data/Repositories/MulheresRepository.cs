using System.Linq.Expressions;
using WEB.Data.Repositories.Interfaces;
using WEB.Models.Entities;

namespace WEB.Data.Repositories
{
    public class MulheresRepository : IMulheresRepository
    {
        private readonly DataContext _dataContext;

        public MulheresRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task AddAsync(Mulheres result)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Mulheres>> GetAllAsync(Expression<Func<Mulheres, bool>> expression, Expression<Func<Mulheres, object>>[] expressions)
        {
            throw new NotImplementedException();
        }

        public Task<(IEnumerable<Mulheres> lista, int count)> GetAllPaginationAsync(Expression<Func<Mulheres, bool>>? expression, int skip)
        {
            throw new NotImplementedException();
        }

        public Task<Mulheres?> GetByIdAllIncludesAsync(Guid id, Expression<Func<Mulheres, bool>>? expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<Mulheres> GetByIdAsync(Guid id)
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

        public Task Remover(Mulheres result)
        {
            throw new NotImplementedException();
        }

        public Task Update(Mulheres result)
        {
            throw new NotImplementedException();
        }
    }
}
