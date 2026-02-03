using Microsoft.AspNetCore.Mvc;
using WEB.Helpers.Messages;
using WEB.Services.Interfaces;

namespace WEB.Controllers
{
    public class RegiaoController : Controller
    {
        private readonly IRegiaoService _regiaoService;

        public RegiaoController(IRegiaoService regiaoService)
        {
            _regiaoService = regiaoService;
        }

        public IActionResult Regiao()
        {
            return View();
        }

        public async Task<IActionResult> CadastroRegiao(Guid? regiaoId)
        {
            var novo = new RegiaoVm();
            if (regiaoId != null) novo = await _regiaoService.GetByIdAsync(regiaoId.Value);

            var superintendentesRegionais = await _regiaoService.GetAllAsync();
            var superintendentesEstaduais = await _regiaoService.GetAllAsync();

            ViewBag.SuperintendentesRegionais = superintendentesRegionais;
            ViewBag.SuperintendentesEstaduais = superintendentesEstaduais;

            ViewBag.Title = regiaoId != null ? "Editar" : "Cadastrar";


            return View("_Cadastro", novo);
        }

        [HttpPost]
        public async Task<IActionResult> AlterarRegiao(RegiaoVm vm)
        {
            string mensagemSucess = "";
            var estadoNovo = await _regiaoService.GetByIdAllIncludesAsync(vm.RegiaoId);

            if (estadoNovo != null)
            {
                await _regiaoService.UpdateAsync(vm);
                mensagemSucess = "Edição, efetuado com sucesso!";
            }
            else
            {
                await _regiaoService.AddAsync(vm);
                mensagemSucess = "Cadastro, efetuado com sucesso!";
            }

            return RedirectToAction("Index", "Regiao").Success(mensagemSucess);
        }
    }
}
