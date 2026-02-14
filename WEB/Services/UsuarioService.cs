using AutoMapper;
using System.Linq.Expressions;
using WEB.Data.Repositories;
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

        public async Task AddAsync(UsuarioVm vm)
        {
            var result = _mapper.Map<Usuario>(vm);
            await _usuarioRepository.AddAsync(result);
        }

        public async Task<bool> ExisteEmailAsync(string email)
        {
            return await _usuarioRepository.GetByEmailAsync(email) != null;
        }

        public async Task<IEnumerable<UsuarioVm>> GetAllAsync(Expression<Func<UsuarioVm, bool>>? expression = null, params Expression<Func<UsuarioVm, object?>>[]? includes)
        {
            var result = await _usuarioRepository.GetAllAsync(
             _mapper.Map<Expression<Func<Usuario, bool>>>(expression),
             _mapper.Map<Expression<Func<Usuario, object>>[]>(includes));
            return _mapper.Map<IEnumerable<UsuarioVm>>(result);
        }

        public async Task<(IEnumerable<UsuarioVm> lista, int count)> GetAllPaginationAsync(Expression<Func<UsuarioVm, bool>>? filtragem, int skip)
        {
            var expressionMap = _mapper.Map<Expression<Func<Usuario, bool>>>(filtragem);
            var (lista, count) = await _usuarioRepository.GetAllPaginationAsync(expressionMap, skip);

            return (_mapper.Map<IEnumerable<UsuarioVm>>(lista), count);
        }

        public async Task<UsuarioVm?> GetByIdAllIncludesAsync(Guid id, Expression<Func<UsuarioVm, bool>>? expression = null)
        {
            var result = await _usuarioRepository.GetByIdAllIncludesAsync(id, _mapper.Map<Expression<Func<Usuario, bool>>>(expression));
            return _mapper.Map<UsuarioVm>(result);
        }

        public async Task<UsuarioVm> GetByIdAsync(Guid id)
        {
            return _mapper.Map<UsuarioVm>(await _usuarioRepository.GetByIdAsync(id));
        }

        public async Task InativarAsync(Guid id)
        {
            await _usuarioRepository.InativarAsync(id);
        }

        public async Task<Usuario?> LoginAsync(string email, string senha)
        {
            var usuario = await _usuarioRepository.GetByEmailAsync(email);

            if (usuario == null)
                return null;

            bool senhaOk = BCrypt.Net.BCrypt.Verify(senha, usuario.SenhaHash);

            return senhaOk ? usuario : null;
        }

        public async Task ReativarAsync(Guid id)
        {
            await _usuarioRepository.ReativarAsync(id);
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

        public async Task<UsuarioVm> Remover(Guid id)
        {
            var result = await _usuarioRepository.GetByIdAsync(id);
            if (result != null)
            {
                _usuarioRepository.Remover(result);
            }

            return _mapper.Map<UsuarioVm>(result);
        }

        public async Task UpdateAsync(UsuarioVm vm)
        {
            Usuario result = _mapper.Map<Usuario>(vm);
            await _usuarioRepository.Update(result);
        }      
    }
}
