using Microsoft.AspNetCore.Mvc;
using WEB.Helpers.Messages;
using WEB.Services;
using WEB.Services.Interfaces;

namespace WEB.Controllers
{
    public class PastoresController : Controller
    {
        private readonly IPastoresService _pastoresService;
        private readonly IIgrejaService _igrejaService;

        public PastoresController(IPastoresService pastoresService, IIgrejaService igrejaService)
        {
            _pastoresService = pastoresService;
            _igrejaService = igrejaService;
        }

        public async Task<IActionResult> Index()
        {
            var igrejas = await _pastoresService.GetAllAsync();
            return View(igrejas);
        }

        public async Task<IActionResult> Cadastrar(Guid? pastorId)
        {
            var novo = new PastoresVm();
            if (pastorId != null) novo = await _pastoresService.GetByIdAsync(pastorId.Value);

            var igreja = await _igrejaService.GetAllAsync();

            ViewBag.Igreja = igreja;
            ViewBag.Title = pastorId != null ? "Editar" : "Cadastrar";

            return PartialView("_Cadastrar", novo);
        }

        [HttpPost]
        public async Task<IActionResult> AlterarPastores(PastoresVm vm)
        {
            string mensagemSucess = "";
            var novo = await _pastoresService.GetByIdAllIncludesAsync(vm.PastorId);

            if (novo != null)
            {
                await _pastoresService.UpdateAsync(vm);
                mensagemSucess = "Edição, efetuado com sucesso!";
            }
            else
            {
                await _pastoresService.AddAsync(vm);
                mensagemSucess = "Cadastro, efetuado com sucesso!";
            }

            return RedirectToAction("Index", "Pastores").Success(mensagemSucess);
        }

        public async Task<IActionResult> Operacao(Guid? pastorId)
        {
            if (pastorId == null)
                return NotFound();

            var item = await _pastoresService.GetByIdAsync(pastorId.Value);

            if (item.Ativo)
            {
                await _pastoresService.InativarAsync(pastorId.Value);
                TempData["success"] = "Igreja inativado e tempo de ministério congelado!";
            }
            else
            {
                await _pastoresService.ReativarAsync(pastorId.Value);
                TempData["success"] = "Igreja reativado! Tempo de ministério voltou a contar.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}