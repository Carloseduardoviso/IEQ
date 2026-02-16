using Microsoft.AspNetCore.Mvc;
using WEB.Helpers.Messages;
using WEB.Models.ViewModels;
using WEB.Services.Interfaces;

namespace WEB.Controllers
{
    public class CasalController : Controller
    {
        private readonly ICasalService _casalService;
        private readonly IRegiaoService _regiaoService;
        private readonly ISuperintendenteEstadualService _superintendenteEstadualService;
        private readonly ISuperintendenteRegionalService _superintendenteRegionalService;
        private readonly IIgrejaService _igrejaService;
        private readonly IPastoresService _pastoresService;

        public CasalController(ICasalService casalService, IRegiaoService regiaoService, ISuperintendenteEstadualService superintendenteEstadualService, ISuperintendenteRegionalService superintendenteRegionalService, IIgrejaService igrejaService, IPastoresService pastoresService)
        {
            _casalService = casalService;
            _regiaoService = regiaoService;
            _superintendenteEstadualService = superintendenteEstadualService;
            _superintendenteRegionalService = superintendenteRegionalService;
            _igrejaService = igrejaService;
            _pastoresService = pastoresService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _casalService.GetAllAsync();
            return View(result);
        }

        public async Task<IActionResult> Detalhe(Guid? casaId)
        {
            var detalhe = await _casalService.GetByIdAsync(casaId.Value);
            return PartialView("_Detalhe", detalhe);
        }

        public async Task<IActionResult> Operacao(Guid? casaId)
        {
            if (casaId == null)
                return NotFound();

            var item = await _casalService.GetByIdAsync(casaId.Value);

            if (item.Ativo)
            {
                await _casalService.InativarAsync(casaId.Value);
                TempData["success"] = "Obreiro inativado e tempo de ministério congelado!";
            }
            else
            {
                await _casalService.ReativarAsync(casaId.Value);
                TempData["success"] = "Obreiro reativado! Tempo de ministério voltou a contar.";
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Cadastrar(Guid? casaId)
        {
            var novo = new CasalVm();
            if (casaId != null) novo = await _casalService.GetByIdAsync(casaId.Value);

            var regiao = await _regiaoService.GetAllAsync();
            var superintendentesRegionais = await _superintendenteRegionalService.GetAllAsync();
            var superintendentesEstaduais = await _superintendenteEstadualService.GetAllAsync();
            var igreja = await _igrejaService.GetAllAsync();
            var pastores = await _pastoresService.GetAllAsync();

            ViewBag.Regiao = regiao;
            ViewBag.SuperintendentesRegionais = superintendentesRegionais;
            ViewBag.SuperintendentesEstaduais = superintendentesEstaduais;
            ViewBag.Igreja = igreja;
            ViewBag.Pastores = pastores;
            ViewBag.Title = casaId != null ? "Editar" : "Cadastrar";

            return PartialView("_Cadastrar", novo);
        }


        [HttpPost]
        public async Task<IActionResult> AlterarCasal(CasalVm vm)
        {
            string mensagemSucess = "";
            var novo = await _casalService.GetByIdAllIncludesAsync(vm.CasalId);

            if (novo != null)
            {
                await _casalService.UpdateAsync(vm);
                mensagemSucess = "Edição, efetuado com sucesso!";
            }
            else
            {
                await _casalService.AddAsync(vm);
                mensagemSucess = "Cadastro, efetuado com sucesso!";
            }

            return RedirectToAction("Index", "Casal").Success(mensagemSucess);
        }
    }
}
