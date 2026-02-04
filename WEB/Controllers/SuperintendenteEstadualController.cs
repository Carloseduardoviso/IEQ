using Microsoft.AspNetCore.Mvc;
using WEB.Helpers.Messages;
using WEB.Models.ViewModels;
using WEB.Services;
using WEB.Services.Interfaces;

namespace WEB.Controllers
{
    public class SuperintendenteEstadualController : Controller
    {
        private readonly ISuperintendenteEstadualService _superintendenteEstadualService;

        public SuperintendenteEstadualController(ISuperintendenteEstadualService superintendenteEstadualService)
        {
            _superintendenteEstadualService = superintendenteEstadualService;
        }

        public async Task<IActionResult> Index()
        {
            var superintendentesEstaduais = await _superintendenteEstadualService.GetAllAsync();

            return View(superintendentesEstaduais);
        }

        public async Task<IActionResult> Cadastrar(Guid? superintendenteEstadualId)
        {
            var novo = new SuperintendenteEstadualVm();
            if (superintendenteEstadualId != null) novo = await _superintendenteEstadualService.GetByIdAsync(superintendenteEstadualId.Value);

            ViewBag.Title = superintendenteEstadualId != null ? "Editar" : "Cadastrar";


            return View("_Cadastro", novo);
        }

        [HttpPost]
        public async Task<IActionResult> AlterarSuperintendenteEstadual(SuperintendenteEstadualVm vm)
        {
            string mensagemSucess = "";
            var estadoNovo = await _superintendenteEstadualService.GetByIdAllIncludesAsync(vm.SuperintendenteEstadualId);

            if (estadoNovo != null)
            {
                await _superintendenteEstadualService.UpdateAsync(vm);
                mensagemSucess = "Edição, efetuado com sucesso!";
            }
            else
            {
                await _superintendenteEstadualService.AddAsync(vm);
                mensagemSucess = "Cadastro, efetuado com sucesso!";
            }

            return RedirectToAction("Index", "SuperintendenteEstadual").Success(mensagemSucess);
        }
    }
}
