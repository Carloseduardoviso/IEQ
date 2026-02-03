using Microsoft.AspNetCore.Mvc;
using WEB.Helpers.Messages;
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