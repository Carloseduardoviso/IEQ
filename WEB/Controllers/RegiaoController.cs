using Microsoft.AspNetCore.Mvc;
using WEB.Helpers.Builder.Filtro;
using WEB.Helpers.Messages;
using WEB.Models.ViewModels.Filtro;
using WEB.Services;
using WEB.Services.Interfaces;

namespace WEB.Controllers
{
    public class RegiaoController : Controller
    {
        private readonly IRegiaoService _regiaoService;
        private readonly ISuperintendenteEstadualService _superintendenteEstadualService;
        private readonly ISuperintendenteRegionalService _superintendenteRegionalService;

        public RegiaoController(IRegiaoService regiaoService, ISuperintendenteEstadualService superintendenteEstadualService, ISuperintendenteRegionalService superintendenteRegionalService)
        {
            _regiaoService = regiaoService;
            _superintendenteEstadualService = superintendenteEstadualService;
            _superintendenteRegionalService = superintendenteRegionalService;
        }

        public async Task<IActionResult> Index(FiltroRegiaoVm filtroRegiaoVm, int pagina = 1)
        {
            filtroRegiaoVm.Search = filtroRegiaoVm.Search ?? string.Empty;
            var filtroFinal = FiltroRegiaoBuilder.Construir(filtroRegiaoVm);

            var (lista, count) = await _regiaoService.GetAllPaginationAsync(filtroFinal, (pagina - 1) * 5);
            int numeroTotalPaginas = (int)Math.Ceiling(count / (double)5);
            pagina = Math.Clamp(pagina, 0, numeroTotalPaginas);

            ViewBag.FiltroRegiao = filtroRegiaoVm;
            ViewBag.NumeroTotalPaginas = numeroTotalPaginas;
            ViewBag.PaginaAtual = pagina;
            ViewBag.TotalRegistro = count;
            ViewBag.TotalExibido = (await _regiaoService.GetAllAsync()).Count();
            return View(lista);
        }

        public async Task<IActionResult> Cadastrar(Guid? regiaoId)
        {
            var novo = new RegiaoVm();
            if (regiaoId != null) novo = await _regiaoService.GetByIdAsync(regiaoId.Value);

            var superintendentesRegionais = await _superintendenteRegionalService.GetAllAsync();
            var superintendentesEstaduais = await _superintendenteEstadualService.GetAllAsync();

            ViewBag.SuperintendentesRegionais = superintendentesRegionais;
            ViewBag.SuperintendentesEstaduais = superintendentesEstaduais;

            ViewBag.Title = regiaoId != null ? "Editar" : "Cadastrar";


            return PartialView("_Cadastrar", novo);
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
