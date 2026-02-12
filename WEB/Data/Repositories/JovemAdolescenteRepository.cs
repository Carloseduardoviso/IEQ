using System.Linq.Expressions;
using WEB.Data.Repositories.Interfaces;
using WEB.Models.Entities;

namespace WEB.Data.Repositories
{
    public class JovemAdolescenteRepository : IJovemAdolescenteRepository
    {
        private readonly DataContext _dataContext;

        public JovemAdolescenteRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task AddAsync(JovemAdolescente result)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<JovemAdolescente>> GetAllAsync(Expression<Func<JovemAdolescente, bool>> expression, Expression<Func<JovemAdolescente, object>>[] expressions)
        {
            throw new NotImplementedException();
        }

        public Task<(IEnumerable<JovemAdolescente> lista, int count)> GetAllPaginationAsync(Expression<Func<JovemAdolescente, bool>>? expression, int skip)
        {
            throw new NotImplementedException();
        }

        public Task<JovemAdolescente?> GetByIdAllIncludesAsync(Guid id, Expression<Func<JovemAdolescente, bool>>? expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<JovemAdolescente> GetByIdAsync(Guid id)
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

        public Task Remover(JovemAdolescente result)
        {
            throw new NotImplementedException();
        }

        public Task Update(JovemAdolescente result)
        {
            throw new NotImplementedException();
        }
    }
}
