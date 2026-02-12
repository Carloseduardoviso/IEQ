
using System.Linq.Expressions;
using WEB.Models.Entities;

namespace WEB.Data.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> GetByEmailAsync(string email);
        Task AddAsync(Usuario usuario);
        Task SaveAsync();
        Task<IEnumerable<Usuario>> GetAllAsync(Expression<Func<Usuario, bool>> expression, Expression<Func<Usuario, object>>[] expressions);
        Task<(IEnumerable<Usuario> lista, int count)> GetAllPaginationAsync(Expression<Func<Usuario, bool>>? expression, int skip);
        Task<Usuario?> GetByIdAllIncludesAsync(Guid id, Expression<Func<Usuario, bool>>? expression = null);
        Task<Usuario> GetByIdAsync(Guid id);
        Task InativarAsync(Guid id);
        Task ReativarAsync(Guid id);
        Task Remover(Usuario result);
        Task Update(Usuario result);
    }
}
