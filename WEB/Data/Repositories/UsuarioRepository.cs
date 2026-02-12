using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WEB.Data.Repositories.Interfaces;
using WEB.Models.Entities;

namespace WEB.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext _dataContext;

        public UsuarioRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(Usuario usuario)
        {
            await _dataContext.Usuarios.AddAsync(usuario);
        }

        public Task<IEnumerable<Usuario>> GetAllAsync(Expression<Func<Usuario, bool>> expression, Expression<Func<Usuario, object>>[] expressions)
        {
            throw new NotImplementedException();
        }

        public Task<(IEnumerable<Usuario> lista, int count)> GetAllPaginationAsync(Expression<Func<Usuario, bool>>? expression, int skip)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            return await _dataContext.Usuarios.FirstOrDefaultAsync(x => x.Email == email);
        }

        public Task<Usuario?> GetByIdAllIncludesAsync(Guid id, Expression<Func<Usuario, bool>>? expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> GetByIdAsync(Guid id)
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

        public Task Remover(Usuario result)
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync()
        {
            await _dataContext.SaveChangesAsync();
        }

        public Task Update(Usuario result)
        {
            throw new NotImplementedException();
        }
    }
}
