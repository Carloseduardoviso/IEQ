using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using WEB.Helpers.Builder.Filtro;
using WEB.Helpers.Messages;
using WEB.Models.ViewModels.Filtro;
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

        public async Task<IActionResult> Index(FiltroIgrejaVm filtroIgrejaVm, int pagina = 1)
        {
            filtroIgrejaVm.Search = NormalizeSearch(filtroIgrejaVm.Search ?? string.Empty);
            var filtroFinal = FiltroIgrejaBuilder.Construir(filtroIgrejaVm);

            var (lista, count) = await _igrejaService.GetAllPaginationAsync(filtroFinal, (pagina - 1) * 5);
            int numeroTotalPaginas = (int)Math.Ceiling(count / (double)5);
            pagina = Math.Clamp(pagina, 0, numeroTotalPaginas);

            ViewBag.FiltroIgreja = filtroIgrejaVm;
            ViewBag.NumeroTotalPaginas = numeroTotalPaginas;
            ViewBag.PaginaAtual = pagina;
            ViewBag.TotalRegistro = count;
            ViewBag.TotalExibido = (await _igrejaService.GetAllAsync()).Count();
            return View(lista);
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

        private string NormalizeSearch(string search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return string.Empty;

            // Remove acentos
            search = RemoverAcentos(search);

            // Remove espaços duplicados
            search = Regex.Replace(search, @"\s+", " ");

            // Remove espaços no início e no fim
            search = search.Trim();

            return search;
        }

        private string RemoverAcentos(string texto)
        {
            return new string(
                texto
                    .Normalize(NormalizationForm.FormD)
                    .Where(ch => CharUnicodeInfo.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                    .ToArray()
            ).Normalize(NormalizationForm.FormC);
        }
    }    
}
