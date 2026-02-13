using Microsoft.EntityFrameworkCore;
using System.Linq;
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

        public async Task<IEnumerable<Usuario>> GetAllAsync(Expression<Func<Usuario, bool>> expression, Expression<Func<Usuario, object>>[] expressions)
        {
            IQueryable<Usuario> query = _dataContext.Usuarios.AsNoTracking();

            query = IncludeAllProperties(query);

            if (expression is not null)
                query = query.Where(expression);

            return await query
                .OrderBy(c => c.NomeCompleto)
                .ToListAsync();
        }

        public async Task<(IEnumerable<Usuario> lista, int count)> GetAllPaginationAsync(Expression<Func<Usuario, bool>>? expression, int skip)
        {
            var query = _dataContext.Usuarios.AsNoTracking();
            query = IncludeAllProperties(query);

            if (expression != null) query = query.Where(expression);
            var lista = await query.Where(x => x.Ativo).OrderBy(x => x.NomeCompleto).Skip(skip).Take(5).ToListAsync();
            var count = await query.CountAsync();

            return (lista, count);
        }

        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            return await _dataContext.Usuarios.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<Usuario?> GetByIdAllIncludesAsync(Guid id, Expression<Func<Usuario, bool>>? expression = null)
        {
            IQueryable<Usuario> query = _dataContext.Usuarios.AsNoTracking();

            query = IncludeAllProperties(query);

            if (expression is not null)
            {
                query = query.Where(expression);
            }

            var result = await query.FirstOrDefaultAsync(e => e.UsuarioId == id);

            return result;
        }

        public async Task<Usuario> GetByIdAsync(Guid id)
        {
            return await IncludeAllProperties(_dataContext.Usuarios)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.UsuarioId == id);
        }

        public Task InativarAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task ReativarAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task Remover(Usuario result)
        {
            _dataContext.Remove(result);
            await _dataContext.SaveChangesAsync();
        }

        public async Task SaveAsync()
        {
            await _dataContext.SaveChangesAsync();
        }

        public async Task Update(Usuario result)
        {
            _dataContext.Usuarios.Update(result);
            await _dataContext.SaveChangesAsync();
        }
    }
}
