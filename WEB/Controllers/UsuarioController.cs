using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WEB.Models.ViewModels;
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

        public IActionResult Index()
        {
            return View();
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

        [HttpPost]
        public async Task<IActionResult> Registrar(RegistrarVm vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            if (await _usuarioService.ExisteEmailAsync(vm.Email!))
            {
                ModelState.AddModelError("", "Email já cadastrado");
                return View(vm);
            }

            await _usuarioService.RegistrarAsync(vm);

            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> EsqueciMinhaSenha(EsqueciMinhaSenhaVm vm)
        {
            var existe = await _usuarioService.ExisteEmailAsync(vm.Email);

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
    }
}
