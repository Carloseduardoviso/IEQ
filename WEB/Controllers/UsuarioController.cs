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
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IIgrejaService _igrejaService;
        private readonly IRegiaoService _regiaoService;

        public UsuarioController(IUsuarioService usuarioService,IIgrejaService igrejaService, IRegiaoService regiaoService)
        {
            _usuarioService = usuarioService;
            _igrejaService = igrejaService;
            _regiaoService = regiaoService;
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

        public async Task<IActionResult> Registrar()
        {
            var igreja = await _igrejaService.GetAllAsync();
            var regiao = await _regiaoService.GetAllAsync();

            ViewBag.Igreja = igreja;
            ViewBag.Regiao = regiao;

            return View();
        } 
        public IActionResult EsqueciMinhaSenha() => View();


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
            new Claim("UserId", usuario.UsuarioId.ToString())
        };

            var identity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity));

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Editar(Guid? usuarioId)
        {
            var novo = new UsuarioVm();
            if (usuarioId != null) novo = await _usuarioService.GetByIdAsync(usuarioId.Value);

            var regiao = await _regiaoService.GetAllAsync();
            var igreja = await _igrejaService.GetAllAsync();

            ViewBag.Regiao = regiao;
            ViewBag.Igreja = igreja;
            ViewBag.Title = usuarioId != null ? "Editar" : "Cadastrar";

            return PartialView("_Editar", novo);
        }


        [HttpPost]
        public async Task<IActionResult> AlterarUsuario(UsuarioVm vm)
        {
            string mensagemSucess = "";
            var novo = await _usuarioService.GetByIdAllIncludesAsync(vm.UsuarioId);

            if (novo != null)
            {
                await _usuarioService.UpdateAsync(vm);
                mensagemSucess = "Edição, efetuado com sucesso!";
            }        

            return RedirectToAction("Index", "Usuario").Success(mensagemSucess);
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(UsuarioVm vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            if (await _usuarioService.ExisteEmailAsync(vm.Email!))
            {
                return View("Registrar", vm).Information("Email já cadastrado");
            }

            await _usuarioService.RegistrarAsync(vm);

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

            var link = Url.Action(
     "RedefinirSenha",   // action
     "Usuario",        // controller
     new { email = vm.Email }, // parâmetro
     Request.Scheme);

            await _usuarioService.EnviarAsync(
                vm.Email,
                "Redefinir senha",
                $"Clique aqui para redefinir sua senha: {link}"
            );

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
