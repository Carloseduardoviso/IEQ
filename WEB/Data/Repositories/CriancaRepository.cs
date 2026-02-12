using System.Linq.Expressions;
using WEB.Data.Repositories.Interfaces;
using WEB.Models.Entities;

namespace WEB.Data.Repositories
{
    public class CriancaRepository : ICriancaRepository
    {
        private readonly DataContext _dataContext;

        public CriancaRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task AddAsync(Crianca result)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Crianca>> GetAllAsync(Expression<Func<Crianca, bool>> expression, Expression<Func<Crianca, object>>[] expressions)
        {
            throw new NotImplementedException();
        }

        public Task<(IEnumerable<Crianca> lista, int count)> GetAllPaginationAsync(Expression<Func<Crianca, bool>>? expression, int skip)
        {
            throw new NotImplementedException();
        }

        public Task<Crianca?> GetByIdAllIncludesAsync(Guid id, Expression<Func<Crianca, bool>>? expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<Crianca> GetByIdAsync(Guid id)
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

        public Task Remover(Crianca result)
        {
            throw new NotImplementedException();
        }

        public Task Update(Crianca result)
        {
            throw new NotImplementedException();
        }
    }
}
