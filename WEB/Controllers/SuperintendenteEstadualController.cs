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


            return PartialView("_Cadastrar", novo);
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

        [HttpPost]
        public async Task<IActionResult> Excluir(Guid superintendenteEstadualId)
        {
            try
            {
                if (superintendenteEstadualId == Guid.Empty) return BadRequest($"Erro na alteração do cidade");

                var paraRemover = await _superintendenteEstadualService.Remover(superintendenteEstadualId);

                var menssagem = "Removido com sucesso!";

                return Json(new
                {
                    id = superintendenteEstadualId,
                    message = menssagem,
                    view = paraRemover
                });
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao remover");
            }
        }
    }
}
