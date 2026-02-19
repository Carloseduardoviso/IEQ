using AutoMapper;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
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
        private readonly IConfiguration _config;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper, IConfiguration config)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _config = config;
        }

        public async Task AddAsync(UsuarioVm vm)
        {
            var result = _mapper.Map<Usuario>(vm);
            await _usuarioRepository.AddAsync(result);
        }

        public async Task<bool> AlterarSenhaAsync(RedefinirSenhaVm vm)
        {
            var usuario = await _usuarioRepository.GetByEmailAsync(vm.Email);

            if (usuario == null)
                return false;

            // gera hash da nova senha
            usuario.SenhaHash = BCrypt.Net.BCrypt.HashPassword(vm.NovaSenha);

            await _usuarioRepository.Update(usuario);

            return true;
        }

        public async Task EnviarAsync(string para, string assunto, string mensagem)
        {
            if (string.IsNullOrWhiteSpace(para))
                throw new Exception("Email destino é obrigatório");

            var fromEmail = _config["Email:Usuario"];

            if (string.IsNullOrWhiteSpace(fromEmail))
                throw new Exception("Email remetente não configurado");

            var smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(
                    fromEmail,
                    _config["Email:Senha"]
                ),
                EnableSsl = true
            };

            var mail = new MailMessage
            {
                From = new MailAddress(fromEmail),
                Subject = assunto,
                Body = mensagem,
                IsBodyHtml = true
            };

            mail.To.Add(para);

            await smtp.SendMailAsync(mail);
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

        public async Task RegistrarAsync(UsuarioVm vm)
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
            var usuario = await _usuarioRepository.GetByIdAsync(vm.UsuarioId);

            if (usuario == null)
                throw new Exception("Usuário não encontrado");

            if (!string.IsNullOrWhiteSpace(vm.Senha))
            {
                usuario.SenhaHash = BCrypt.Net.BCrypt.HashPassword(vm.Senha);
            }

            await _usuarioRepository.Update(usuario);
        }
    }
}
