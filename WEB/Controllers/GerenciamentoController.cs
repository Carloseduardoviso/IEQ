using Microsoft.AspNetCore.Mvc;
using WEB.Services.Interfaces;

namespace WEB.Controllers
{
    public class GerenciamentoController : Controller
    {
        public readonly IGerenciamentoService _gerenciamentoService;

        public GerenciamentoController(IGerenciamentoService gerenciamentoService)
        {
            _gerenciamentoService = gerenciamentoService;
        }

        #region GET
        public IActionResult Regiao()
        {
            return View("Regiao/Index");
        }

        public IActionResult SuperintendenteRegional()
        {
            return View("SuperintendenteRegional/Index");
        }

        public IActionResult SuperintendenteEstadual()
        {
            return View("SuperintendenteEstadual/Index");
        }

        public IActionResult Igreja()
        {
            return View("Igreja/Index");
        }
        public IActionResult Pastores()
        {
            return View("Pastores/Index");
        }
        #endregion

        #region Cadastros

        public async Task<IActionResult> CadastroRegiao(Guid? regiaoId)
        {
            var novo = new RegiaoVm();
            if (regiaoId != null) novo = await _gerenciamentoService.GetByIdRegiaoAsync(regiaoId.Value);

            ViewBag.Title = regiaoId != null ? "Editar" : "Cadastrar";


            return View("Regiao/_Cadastro", novo);
        }

        public IActionResult CadastroSuperintendenteRegional()
        {
            return View("SuperintendenteRegional/Cadastro");
        }

        public IActionResult CadastroSuperintendenteEstadual()
        {
            return View("SuperintendenteEstadual/Cadastro");
        }
        public IActionResult CadastroIgreja()
        {
            return View("Igreja/Cadastro");
        }

        public IActionResult CadastroPastores()
        {
            return View("Pastores/Cadastro");
        }
        #endregion
    }
}