using AutoMapper;
using WEB.Data.Repositories.Interfaces;
using WEB.Models.Entities;
using WEB.Models.ViewModels;
using WEB.Services.Interfaces;

namespace WEB.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<bool> ExisteEmailAsync(string email)
        {
            return await _usuarioRepository.GetByEmailAsync(email) != null;
        }

        public async Task<Usuario?> LoginAsync(string email, string senha)
        {
            var usuario = await _usuarioRepository.GetByEmailAsync(email);

            if (usuario == null)
                return null;

            bool senhaOk = BCrypt.Net.BCrypt.Verify(senha, usuario.SenhaHash);

            return senhaOk ? usuario : null;
        }

        public async Task RegistrarAsync(RegistrarVm vm)
        {
            var usuario = new Usuario
            {
                UsuarioId = Guid.NewGuid(),
                Nome = vm.Nome,
                Email = vm.Email,
                SenhaHash = BCrypt.Net.BCrypt.HashPassword(vm.Senha),
                RegiaoId = vm.RegiaoId,
                IgrejaId = vm.IgrejaId,
                Role = vm.Role,
                DataCriacao = DateTime.Now
            };

            await _usuarioRepository.AddAsync(usuario);
            await _usuarioRepository.SaveAsync();
        }
    }
}
