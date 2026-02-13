
using System.Linq.Expressions;
using WEB.Models.Entities;
using WEB.Models.ViewModels;

namespace WEB.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario?> LoginAsync(string email, string senha);
        Task RegistrarAsync(RegistrarVm vm);
        Task<bool> ExisteEmailAsync(string email);

        Task AddAsync(UsuarioVm vm);
        Task UpdateAsync(UsuarioVm vm);
        Task<UsuarioVm> GetByIdAsync(Guid id);
        Task<UsuarioVm> Remover(Guid id);
        Task<UsuarioVm?> GetByIdAllIncludesAsync(Guid id, Expression<Func<UsuarioVm, bool>>? expression = null);

        Task<IEnumerable<UsuarioVm>> GetAllAsync(Expression<Func<UsuarioVm, bool>>? expression = null, params Expression<Func<UsuarioVm, object?>>[]? includes);
        Task<(IEnumerable<UsuarioVm> lista, int count)> GetAllPaginationAsync(Expression<Func<UsuarioVm, bool>>? filtragem, int skip);
        Task InativarAsync(Guid id);
        Task ReativarAsync(Guid id);
    }
}