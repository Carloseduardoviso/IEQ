
using WEB.Models.Entities;

namespace WEB.Data.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> GetByEmailAsync(string email);
        Task AddAsync(Usuario usuario);
        Task SaveAsync();
    }
}
