using Microsoft.AspNetCore.Mvc;
using WEB.Helpers.Messages;
using WEB.Models.ViewModels;
using WEB.Services.Interfaces;

namespace WEB.Controllers
{
    public class SuperintendenteRegionalController : Controller
    {
        private readonly ISuperintendenteRegionalService _superintendenteRegionalService;

        public SuperintendenteRegionalController(ISuperintendenteRegionalService superintendenteRegionalService)
        {
            _superintendenteRegionalService = superintendenteRegionalService;
        }

        public async Task<IActionResult> Index()
        {
            var superintendentesRegionais = await _superintendenteRegionalService.GetAllAsync();

            return View(superintendentesRegionais);
        }

        public async Task<IActionResult> Cadastro(Guid? superintendenteRegionalId)
        {
            var novo = new SuperintendenteRegionalVm();
            if (superintendenteRegionalId != null) novo = await _superintendenteRegionalService.GetByIdAsync(superintendenteRegionalId.Value);

            ViewBag.Title = superintendenteRegionalId != null ? "Editar" : "Cadastrar";


            return View("_Cadastro", novo);
        }

        [HttpPost]
        public async Task<IActionResult> Alterar(SuperintendenteRegionalVm vm)
        {
            string mensagemSucess = "";
            var estadoNovo = await _superintendenteRegionalService.GetByIdAllIncludesAsync(vm.SuperintendenteRegionalId);

            if (estadoNovo != null)
            {
                await _superintendenteRegionalService.UpdateAsync(vm);
                mensagemSucess = "Edição, efetuado com sucesso!";
            }
            else
            {
                await _superintendenteRegionalService.AddAsync(vm);
                mensagemSucess = "Cadastro, efetuado com sucesso!";
            }

            return RedirectToAction("Index", "SuperintendenteRegional").Success(mensagemSucess);
        }
    }
}
