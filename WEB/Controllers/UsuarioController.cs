using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WEB.Helpers.Builder.Filtro;
using WEB.Helpers.Messages;
using WEB.Models.Entities;
using WEB.Models.ViewModels;
using WEB.Models.ViewModels.Filtro;
using WEB.Services;
using WEB.Services.Interfaces;

namespace WEB.Controllers
{
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IIgrejaService _igrejaService;
        private readonly IRegiaoService _regiaoService;
        private readonly ISuperintendenteEstadualService _superintendenteEstadualService;
        private readonly ISuperintendenteRegionalService _superintendenteRegionalService;
        private readonly IMembroService _membroService;
        private readonly IPastoresService _pastoresService;

        public UsuarioController(IUsuarioService usuarioService, IIgrejaService igrejaService, IRegiaoService regiaoService, IMembroService membroService, IPastoresService pastoresService, ISuperintendenteEstadualService superintendenteEstadualService, ISuperintendenteRegionalService superintendenteRegionalService)
        {
            _usuarioService = usuarioService;
            _igrejaService = igrejaService;
            _regiaoService = regiaoService;
            _membroService = membroService;
            _pastoresService = pastoresService;
            _superintendenteEstadualService = superintendenteEstadualService;
            _superintendenteRegionalService = superintendenteRegionalService;
        }

        public async Task<IActionResult> Index(FiltroUsuarioVm filtroUsuarioVm, int pagina = 1)
        {
            filtroUsuarioVm.Search = filtroUsuarioVm.Search ?? string.Empty;
            var filtroFinal = FiltroUsuarioBuilder.Construir(filtroUsuarioVm);

            var (lista, count) = await _usuarioService.GetAllPaginationAsync(filtroFinal, (pagina - 1) * 5);
            int numeroTotalPaginas = (int)Math.Ceiling(count / (double)5);
            pagina = Math.Clamp(pagina, 0, numeroTotalPaginas);


            ViewBag.FiltroUsuario = filtroUsuarioVm;
            ViewBag.NumeroTotalPaginas = numeroTotalPaginas;
            ViewBag.PaginaAtual = pagina;
            ViewBag.TotalRegistro = count;
            ViewBag.TotalExibido = (await _usuarioService.GetAllAsync()).Count();
            return View(lista);
        }

        public IActionResult Login() => View();

        public async Task<IActionResult> Registrar(Guid? usuarioId)
        {
            var novo = new UsuarioVm();
            if (usuarioId != null) novo = await _usuarioService.GetByIdAsync(usuarioId.Value);

            var regiao = await _regiaoService.GetAllAsync();
            var ids = regiao.Select(x => x.SuperintendenteRegionalId).ToList();

            var superintendentesRegionais = await _superintendenteRegionalService
                .GetAllAsync(x => ids.Contains(x.SuperintendenteRegionalId));

            //var superintendentesEstaduais = await _superintendenteEstadualService.GetAllAsync(x => x.SuperintendenteEstadualId == regiao.Select(x =>x.SuperintendenteEstadualId);
            var igreja = await _igrejaService.GetAllAsync();
            var pastores = await _pastoresService.GetAllAsync();
            var estados = GetEstados(novo?.Estado);

            ViewBag.Igreja = igreja;
            ViewBag.SuperintendentesRegionais = superintendentesRegionais;
            //ViewBag.SuperintendentesEstaduais = superintendentesEstaduais;
            ViewBag.Regiao = regiao;
            ViewBag.Estados = estados;
            ViewBag.Pastores = pastores;
            ViewBag.Cidades = GetCidades(novo?.Estado!);

            return View();
        }

        public IActionResult EsqueciMinhaSenha() => View();       

        public async Task<IActionResult> Perfil()
        {
            var usuarioId = User.FindFirst("UserId")?.Value;
            var usuario = await _usuarioService.GetByIdAsync(Guid.Parse(usuarioId));

            return View(usuario);
        }           


        [HttpPost]
        public async Task<IActionResult> Login(LoginVm model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var usuario = await _usuarioService.LoginAsync(
                model.Email!, model.Senha!);

            if (usuario == null)
            {
                ModelState.AddModelError("", "Email ou senha inválidos");
                return View(model);
            }

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, usuario.Nome!),
            new Claim(ClaimTypes.Role, usuario.Role.ToString()),
            new Claim("UserId", usuario.UsuarioId.ToString()),
            new Claim("FotoUrl", usuario.FotoUrl ?? "/images/Home/foto_padrao.png")
        };

            var identity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity));

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Cadastrar(Guid? usuarioId)
        {
            var novo = new UsuarioVm();
            if (usuarioId != null) novo = await _usuarioService.GetByIdAsync(usuarioId.Value);

            var regiao = await _regiaoService.GetAllAsync();
            var igreja = await _igrejaService.GetAllAsync();
            var estados = GetEstados(novo?.Estado);

            ViewBag.Regiao = regiao;
            ViewBag.Igreja = igreja; 
            ViewBag.Estados = estados;
            ViewBag.Cidades = GetCidades(novo?.Estado!);

            ViewBag.Title = usuarioId != null ? "Editar" : "Cadastrar";

            return PartialView("_Cadastrar", novo);
        }


        [HttpGet]
        public async Task<IActionResult> GetRegioes(Guid superintendenteId)
        {
            var regioes = await _regiaoService
                .GetAllAsync(x => x.SuperintendenteRegionalId == superintendenteId);

            return Json(regioes.Select(x => new {
                id = x.RegiaoId,
                text = x.Nome
            }));
        }

        [HttpGet]
        public async Task<IActionResult> GetIgrejas(Guid regiaoId)
        {
            var igrejas = await _igrejaService.GetAllAsync(x => x.RegiaoId == regiaoId);

            var result = igrejas.Select(x => new {
                id = x.IgrejaId,
                text = x.Nome
            });

            return Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetPastores(Guid igrejaId)
        {
            var pastores = await _pastoresService.GetAllAsync(x => x.IgrejaId == igrejaId);

            var result = pastores.Select(x => new {
                id = x.PastorId,
                text = x.Nome
            });

            return Json(result);
        }
      

        [HttpPost]
        public async Task<IActionResult> AlterarUsuario(UsuarioVm vm)
        {
            string mensagemSucesso;

            // 📸 Salvar foto de perfil
            if (vm.Foto != null)
            {
                var pasta = Path.Combine("wwwroot", "images", "usuario", "perfil");

                if (!Directory.Exists(pasta))
                    Directory.CreateDirectory(pasta);

                // 🔥 nome único (evita sobrescrever)
                var nomeArquivo = Guid.NewGuid() + Path.GetExtension(vm.Foto.FileName);
                var caminhoCompleto = Path.Combine(pasta, nomeArquivo);

                using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    await vm.Foto.CopyToAsync(stream);
                }

                vm.FotoUrl = "/images/usuario/perfil/" + nomeArquivo;
            }

            // 🔎 Verifica se já existe
            var existente = await _usuarioService.GetByIdAsync(vm.UsuarioId);

            if (existente != null)
            {
                await _usuarioService.UpdateAsync(vm);
                mensagemSucesso = "Edição realizada com sucesso!";
            }
            else
            {
                await _usuarioService.AddAsync(vm);
                mensagemSucesso = "Cadastro realizado com sucesso!";
            }

            // 🔥 ATUALIZA CLAIMS SE FOR O USUÁRIO LOGADO
            var userIdLogado = User.FindFirst("UserId")?.Value;

            if (userIdLogado == vm.UsuarioId.ToString())
            {
                var usuarioAtualizado = await _usuarioService.GetByIdAsync(vm.UsuarioId);

                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, usuarioAtualizado.Nome!),
            new Claim(ClaimTypes.Role, usuarioAtualizado.Role.ToString()),
            new Claim("UserId", usuarioAtualizado.UsuarioId.ToString()),
            new Claim("FotoUrl", usuarioAtualizado.FotoUrl ?? "/images/Home/foto_padrao.png")
        };

                var identity = new ClaimsIdentity(
                    claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity));
            }

            return RedirectToAction("Index", "Usuario")
                .Success(mensagemSucesso);
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(UsuarioVm vm)
        {
            if (!ModelState.IsValid) return View(vm);

            if (await _usuarioService.ExisteEmailAsync(vm.Email!))
            {
                return View("Registrar", vm).Information("Email já cadastrado");
            }

            if (vm.Foto != null)
            {
                var pasta = Path.Combine("wwwroot", "images", "usuario", "perfil");

                if (!Directory.Exists(pasta))
                    Directory.CreateDirectory(pasta);

                var nomeArquivo = vm.Nome + Path.GetExtension(vm.Foto.FileName);
                var caminhoCompleto = Path.Combine(pasta, nomeArquivo);

                using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    await vm.Foto.CopyToAsync(stream);
                }

                vm.FotoUrl = "/images/usuario/perfil/" + nomeArquivo;
            }

            await _usuarioService.RegistrarAsync(vm);


            var 
            return RedirectToAction("Login");
        }

        public IActionResult RedefinirSenha(string email)
        {
            return View(new RedefinirSenhaVm { Email = email });
        }

        [HttpPost]
        public async Task<IActionResult> RedefinirSenha(RedefinirSenhaVm vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var sucesso = await _usuarioService.AlterarSenhaAsync(vm);

            if (!sucesso)
            {
                ModelState.AddModelError("", "Senha atual incorreta");
                return View(vm);
            }

            TempData["msg"] = "Senha alterada com sucesso!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EsqueciMinhaSenha(EsqueciMinhaSenhaVm vm)
        {
            var existe = await _usuarioService.ExisteEmailAsync(vm.Email);
            var link = Url.Action("RedefinirSenha", "Usuario", new { email = vm.Email }, Request.Scheme);
            await _usuarioService.EnviarAsync(vm.Email, "Redefinir senha", $"Clique aqui para redefinir sua senha: {link}");

            if (existe)
                TempData["msg"] = "Link enviado para o email!";
            else
                TempData["msg"] = "Email não encontrado";

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Usuario");
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(Guid usuarioId)
        {
            try
            {
                if (usuarioId == Guid.Empty) return BadRequest($"Erro na alteração do estado");

                var paraRemover = await _usuarioService.Remover(usuarioId);

                string menssagem = "Estado removido com sucesso!";

                return Json(new
                {
                    id = usuarioId,
                    message = menssagem,
                    view = paraRemover
                });
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao remover");
            }
        }

        public string GerarHash(string senha)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(senha);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
