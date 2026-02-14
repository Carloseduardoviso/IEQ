using Microsoft.AspNetCore.Mvc;
using WEB.Helpers.Messages;
using WEB.Models.ViewModels;
using WEB.Services.Interfaces;

namespace WEB.Controllers
{
    public class CriancaController : Controller
    {
        private readonly ICriancaService _criancaService;
        private readonly IRegiaoService _regiaoService;
        private readonly ISuperintendenteEstadualService _superintendenteEstadualService;
        private readonly ISuperintendenteRegionalService _superintendenteRegionalService;
        private readonly IIgrejaService _igrejaService;
        private readonly IPastoresService _pastoresService;

        public CriancaController(ICriancaService criancaService, IRegiaoService regiaoService, ISuperintendenteEstadualService superintendenteEstadualService, ISuperintendenteRegionalService superintendenteRegionalService, IIgrejaService igrejaService, IPastoresService pastoresService)
        {
            _criancaService = criancaService;
            _regiaoService = regiaoService;
            _superintendenteEstadualService = superintendenteEstadualService;
            _superintendenteRegionalService = superintendenteRegionalService;
            _igrejaService = igrejaService;
            _pastoresService = pastoresService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _criancaService.GetAllAsync();
            return View(result);
        }

        public async Task<IActionResult> Detalhe(Guid? criancaId)
        {
            var detalhe = await _criancaService.GetByIdAsync(criancaId.Value);
            return PartialView("_Detalhe", detalhe);
        }

        public async Task<IActionResult> Operacao(Guid? criancaId)
        {
            if (criancaId == null)
                return NotFound();

            var item = await _criancaService.GetByIdAsync(criancaId.Value);

            if (item.Ativo)
            {
                await _criancaService.InativarAsync(criancaId.Value);
                TempData["success"] = "Obreiro inativado e tempo de ministério congelado!";
            }
            else
            {
                await _criancaService.ReativarAsync(criancaId.Value);
                TempData["success"] = "Obreiro reativado! Tempo de ministério voltou a contar.";
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Cadastrar(Guid? criancaId)
        {
            var novo = new CriancaVm();
            if (criancaId != null) novo = await _criancaService.GetByIdAsync(criancaId.Value);

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
            ViewBag.Title = criancaId != null ? "Editar" : "Cadastrar";

            return PartialView("_Cadastrar", novo);
        }     


        [HttpPost]
        public async Task<IActionResult> AlterarIgreja(CriancaVm vm)
        {
            string mensagemSucess = "";
            var novo = await _criancaService.GetByIdAllIncludesAsync(vm.CriancaId);

            if (novo != null)
            {
                await _criancaService.UpdateAsync(vm);
                mensagemSucess = "Edição, efetuado com sucesso!";
            }
            else
            {
                await _criancaService.AddAsync(vm);
                mensagemSucess = "Cadastro, efetuado com sucesso!";
            }

            return RedirectToAction("Index", "Crianca").Success(mensagemSucess);
        }
    }
}