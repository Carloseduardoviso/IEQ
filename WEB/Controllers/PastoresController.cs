using Microsoft.AspNetCore.Mvc;
using WEB.Helpers.Builder.Filtro;
using WEB.Helpers.Messages;
using WEB.Models.ViewModels.Filtro;
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

        public async Task<IActionResult> Index(FiltroPastoresVm filtroPastoresVm, int pagina = 1)
        {
            filtroPastoresVm.Search = filtroPastoresVm.Search ?? string.Empty;
            var filtroFinal = FiltroPastoresBuilder.Construir(filtroPastoresVm);

            var (lista, count) = await _pastoresService.GetAllPaginationAsync(filtroFinal, (pagina - 1) * 5);
            int numeroTotalPaginas = (int)Math.Ceiling(count / (double)5);
            pagina = Math.Clamp(pagina, 0, numeroTotalPaginas);


            ViewBag.FiltroPastores = filtroPastoresVm;
            ViewBag.NumeroTotalPaginas = numeroTotalPaginas;
            ViewBag.PaginaAtual = pagina;
            ViewBag.TotalRegistro = count;
            ViewBag.TotalExibido = (await _pastoresService.GetAllAsync()).Count();
            return View(lista);
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