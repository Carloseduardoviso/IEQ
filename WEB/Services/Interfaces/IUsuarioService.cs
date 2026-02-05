
using WEB.Models.Entities;
using WEB.Models.ViewModels;

namespace WEB.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario?> LoginAsync(string email, string senha);
        Task RegistrarAsync(RegistrarVm vm);
        Task<bool> ExisteEmailAsync(string email);
    }
}