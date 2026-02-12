using System.Linq.Expressions;
using WEB.Data.Repositories.Interfaces;
using WEB.Models.Entities;

namespace WEB.Data.Repositories
{
    public class LouvorRepository : ILouvorRepository
    {
        private readonly DataContext _dataContext;

        public LouvorRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task AddAsync(Louvor result)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Louvor>> GetAllAsync(Expression<Func<Louvor, bool>> expression, Expression<Func<Louvor, object>>[] expressions)
        {
            throw new NotImplementedException();
        }

        public Task<(IEnumerable<Louvor> lista, int count)> GetAllPaginationAsync(Expression<Func<Louvor, bool>>? expression, int skip)
        {
            throw new NotImplementedException();
        }

        public Task<Louvor?> GetByIdAllIncludesAsync(Guid id, Expression<Func<Louvor, bool>>? expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<Louvor> GetByIdAsync(Guid id)
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

        public Task Remover(Louvor result)
        {
            throw new NotImplementedException();
        }

        public Task Update(Louvor result)
        {
            throw new NotImplementedException();
        }
    }
}
