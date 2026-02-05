using Microsoft.EntityFrameworkCore;
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

        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            return await _dataContext.Usuarios.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task SaveAsync()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}
