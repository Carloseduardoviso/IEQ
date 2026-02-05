using Microsoft.AspNetCore.Mvc;
using WEB.Helpers.Messages;
using WEB.Services;
using WEB.Services.Interfaces;

namespace WEB.Controllers
{
    public class IgrejaController : Controller
    {
        private readonly IIgrejaService _igrejaService;
        private readonly IRegiaoService _regiaoService;

        public IgrejaController(IIgrejaService igrejaService, IRegiaoService regiaoService)
        {
            _igrejaService = igrejaService;
            _regiaoService = regiaoService;
        }

        public async Task<IActionResult> Index()
        {
            var igrejas = await _igrejaService.GetAllAsync();
            return View(igrejas);
        }

        public async Task<IActionResult> Cadastrar(Guid? igrejaId)
        {
            var novo = new IgrejaVm();
            if (igrejaId != null) novo = await _igrejaService.GetByIdAsync(igrejaId.Value);

            var regiao = await _regiaoService.GetAllAsync();

            ViewBag.Regiao = regiao;
            ViewBag.Title = igrejaId != null ? "Editar" : "Cadastrar";

            return PartialView("_Cadastrar", novo);
        }

        [HttpPost]
        public async Task<IActionResult> AlterarIgreja(IgrejaVm vm)
        {
            string mensagemSucess = "";
            var novo = await _igrejaService.GetByIdAllIncludesAsync(vm.IgrejaId);

            if (novo != null)
            {
                await _igrejaService.UpdateAsync(vm);
                mensagemSucess = "Edição, efetuado com sucesso!";
            }
            else
            {
                await _igrejaService.AddAsync(vm);
                mensagemSucess = "Cadastro, efetuado com sucesso!";
            }

            return RedirectToAction("Index", "Igreja").Success(mensagemSucess);
        }

        public async Task<IActionResult> Operacao(Guid? igrejaId)
        {
            if (igrejaId == null)
                return NotFound();

            var item = await _igrejaService.GetByIdAsync(igrejaId.Value);

            if (item.Ativo)
            {
                await _igrejaService.InativarAsync(igrejaId.Value);
                TempData["success"] = "Igreja inativado e tempo de ministério congelado!";
            }
            else
            {
                await _igrejaService.ReativarAsync(igrejaId.Value);
                TempData["success"] = "Igreja reativado! Tempo de ministério voltou a contar.";
            }

            return RedirectToAction(nameof(Index));
        }
    }    
}
