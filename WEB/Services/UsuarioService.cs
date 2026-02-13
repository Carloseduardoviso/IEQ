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

        public Task AddAsync(UsuarioVm vm)
        {
            var result = _mapper.Map<Crianca>(vm);
            await _criancaRepository.AddAsync(result);
        }

        public async Task<bool> ExisteEmailAsync(string email)
        {
            return await _usuarioRepository.GetByEmailAsync(email) != null;
        }

        public Task<IEnumerable<UsuarioVm>> GetAllAsync(Expression<Func<UsuarioVm, bool>>? expression = null, params Expression<Func<UsuarioVm, object?>>[]? includes)
        {
            var result = await _criancaRepository.GetAllAsync(
             _mapper.Map<Expression<Func<Crianca, bool>>>(expression),
             _mapper.Map<Expression<Func<Crianca, object>>[]>(includes));
            return _mapper.Map<IEnumerable<CriancaVm>>(result);
        }

        public Task<(IEnumerable<UsuarioVm> lista, int count)> GetAllPaginationAsync(Expression<Func<UsuarioVm, bool>>? filtragem, int skip)
        {
            var expressionMap = _mapper.Map<Expression<Func<Crianca, bool>>>(filtragem);
            var (lista, count) = await _criancaRepository.GetAllPaginationAsync(expressionMap, skip);

            return (_mapper.Map<IEnumerable<CriancaVm>>(lista), count);
        }

        public Task<UsuarioVm?> GetByIdAllIncludesAsync(Guid id, Expression<Func<UsuarioVm, bool>>? expression = null)
        {
            var result = await _criancaRepository.GetByIdAllIncludesAsync(id, _mapper.Map<Expression<Func<Crianca, bool>>>(expression));
            return _mapper.Map<CriancaVm>(result);
        }

        public Task<UsuarioVm> GetByIdAsync(Guid id)
        {
            return _mapper.Map<CriancaVm>(await _criancaRepository.GetByIdAsync(id));
        }

        public Task InativarAsync(Guid id)
        {
            await _criancaRepository.InativarAsync(id);
        }

        public async Task<Usuario?> LoginAsync(string email, string senha)
        {
            var usuario = await _usuarioRepository.GetByEmailAsync(email);

            if (usuario == null)
                return null;

            bool senhaOk = BCrypt.Net.BCrypt.Verify(senha, usuario.SenhaHash);

            return senhaOk ? usuario : null;
        }

        public Task ReativarAsync(Guid id)
        {
            await _criancaRepository.ReativarAsync(id);
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

        public Task<UsuarioVm> Remover(Guid id)
        {
            var result = await _igrejaRepository.GetByIdAsync(igrejaId);
            if (result != null)
            {
                _igrejaRepository.Remover(result);
            }

            return _mapper.Map<IgrejaVm>(result);
        }

        public Task UpdateAsync(UsuarioVm vm)
        {
            Crianca result = _mapper.Map<Crianca>(vm);
            await _criancaRepository.Update(result);
        }
    }
}
