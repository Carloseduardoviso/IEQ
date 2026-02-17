using Microsoft.AspNetCore.Mvc;
using WEB.Helpers.Builder.Filtro;
using WEB.Helpers.Messages;
using WEB.Models.ViewModels;
using WEB.Models.ViewModels.Filtro;
using WEB.Services;
using WEB.Services.Interfaces;

namespace WEB.Controllers
{
    public class JovemAdolescenteController : Controller
    {
        private readonly IJovemAdolescenteService _jovemAdolescenteService;
        private readonly IRegiaoService _regiaoService;
        private readonly ISuperintendenteEstadualService _superintendenteEstadualService;
        private readonly ISuperintendenteRegionalService _superintendenteRegionalService;
        private readonly IIgrejaService _igrejaService;
        private readonly IPastoresService _pastoresService;

        public JovemAdolescenteController(IJovemAdolescenteService jovemAdolescenteService, IRegiaoService regiaoService, ISuperintendenteEstadualService superintendenteEstadualService, ISuperintendenteRegionalService superintendenteRegionalService, IIgrejaService igrejaService, IPastoresService pastoresService)
        {
            _jovemAdolescenteService = jovemAdolescenteService;
            _regiaoService = regiaoService;
            _superintendenteEstadualService = superintendenteEstadualService;
            _superintendenteRegionalService = superintendenteRegionalService;
            _igrejaService = igrejaService;
            _pastoresService = pastoresService;
        }

        public async Task<IActionResult> Index(FiltroJovemAdolescenteVm filtroJovemAdolescenteVm, int pagina = 1)
        {
            filtroJovemAdolescenteVm.Search = filtroJovemAdolescenteVm.Search ?? string.Empty;
            var filtroFinal = FiltroJovemAdolescenteBuilder.Construir(filtroJovemAdolescenteVm);

            var (lista, count) = await _jovemAdolescenteService.GetAllPaginationAsync(filtroFinal, (pagina - 1) * 5);
            int numeroTotalPaginas = (int)Math.Ceiling(count / (double)5);
            pagina = Math.Clamp(pagina, 0, numeroTotalPaginas);

            ViewBag.FiltroJovemAdolescente = filtroJovemAdolescenteVm;
            ViewBag.NumeroTotalPaginas = numeroTotalPaginas;
            ViewBag.PaginaAtual = pagina;
            ViewBag.TotalRegistro = count;
            ViewBag.TotalExibido = (await _jovemAdolescenteService.GetAllAsync()).Count();
            return View(lista);
        }

        public async Task<IActionResult> Detalhe(Guid? jovemAdolecenteId)
        {
            var detalhe = await _jovemAdolescenteService.GetByIdAsync(jovemAdolecenteId.Value);
            return PartialView("_Detalhe", detalhe);
        }

        public async Task<IActionResult> Operacao(Guid? jovemAdolecenteId)
        {
            if (jovemAdolecenteId == null)
                return NotFound();

            var item = await _jovemAdolescenteService.GetByIdAsync(jovemAdolecenteId.Value);

            if (item.Ativo)
            {
                await _jovemAdolescenteService.InativarAsync(jovemAdolecenteId.Value);
                TempData["success"] = "Obreiro inativado e tempo de ministério congelado!";
            }
            else
            {
                await _jovemAdolescenteService.ReativarAsync(jovemAdolecenteId.Value);
                TempData["success"] = "Obreiro reativado! Tempo de ministério voltou a contar.";
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Cadastrar(Guid? jovemAdolecenteId)
        {
            var novo = new JovemAdolescenteVm();
            if (jovemAdolecenteId != null) novo = await _jovemAdolescenteService.GetByIdAsync(jovemAdolecenteId.Value);

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
            ViewBag.Title = jovemAdolecenteId != null ? "Editar" : "Cadastrar";

            return PartialView("_Cadastrar", novo);
        }


        [HttpPost]
        public async Task<IActionResult> AlterarIgreja(JovemAdolescenteVm vm)
        {
            string mensagemSucess = "";
            var novo = await _jovemAdolescenteService.GetByIdAllIncludesAsync(vm.JovemAdolecenteId);

            if (novo != null)
            {
                await _jovemAdolescenteService.UpdateAsync(vm);
                mensagemSucess = "Edição, efetuado com sucesso!";
            }
            else
            {
                await _jovemAdolescenteService.AddAsync(vm);
                mensagemSucess = "Cadastro, efetuado com sucesso!";
            }

            return RedirectToAction("Index", "JovemAdolescente").Success(mensagemSucess);
        }
    }
}
