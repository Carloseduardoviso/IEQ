using Microsoft.AspNetCore.Mvc;
using WEB.Helpers.Builder.Filtro;
using WEB.Helpers.Messages;
using WEB.Models.ViewModels;
using WEB.Models.ViewModels.Filtro;
using WEB.Services;
using WEB.Services.Interfaces;

namespace WEB.Controllers
{
    public class SuperintendenteRegionalController : Controller
    {
        private readonly ISuperintendenteRegionalService _superintendenteRegionalService;

        public SuperintendenteRegionalController(ISuperintendenteRegionalService superintendenteRegionalService)
        {
            _superintendenteRegionalService = superintendenteRegionalService;
        }

        public async Task<IActionResult> Index(FiltroSuperintendenteRegionalVm filtroSuperintendenteRegionalVm, int pagina = 1)
        {
            filtroSuperintendenteRegionalVm.Search = filtroSuperintendenteRegionalVm.Search ?? string.Empty;
            var filtroFinal = FiltroSuperintendenteRegionalBuilder.Construir(filtroSuperintendenteRegionalVm);

            var (lista, count) = await _superintendenteRegionalService.GetAllPaginationAsync(filtroFinal, (pagina - 1) * 5);
            int numeroTotalPaginas = (int)Math.Ceiling(count / (double)5);
            pagina = Math.Clamp(pagina, 0, numeroTotalPaginas);


            ViewBag.FiltroSuperintendenteRegional = filtroSuperintendenteRegionalVm;
            ViewBag.NumeroTotalPaginas = numeroTotalPaginas;
            ViewBag.PaginaAtual = pagina;
            ViewBag.TotalRegistro = count;
            ViewBag.TotalExibido = (await _superintendenteRegionalService.GetAllAsync()).Count();
            return View(lista);
        }

        public async Task<IActionResult> Cadastrar(Guid? superintendenteRegionalId)
        {
            var novo = new SuperintendenteRegionalVm();
            if (superintendenteRegionalId != null) novo = await _superintendenteRegionalService.GetByIdAsync(superintendenteRegionalId.Value);

            ViewBag.Title = superintendenteRegionalId != null ? "Editar" : "Cadastrar";


            return PartialView("_Cadastrar", novo);
        }

        [HttpPost]
        public async Task<IActionResult> Alterar(SuperintendenteRegionalVm vm)
        {
            string mensagemSucess = "";
            var estadoNovo = await _superintendenteRegionalService.GetByIdAllIncludesAsync(vm.SuperintendenteRegionalId);

            if (estadoNovo != null)
            {
                await _superintendenteRegionalService.UpdateAsync(vm);
                mensagemSucess = "Edição, efetuado com sucesso!";
            }
            else
            {
                await _superintendenteRegionalService.AddAsync(vm);
                mensagemSucess = "Cadastro, efetuado com sucesso!";
            }

            return RedirectToAction("Index", "SuperintendenteRegional").Success(mensagemSucess);
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(Guid superintendenteRegionalId)
        {
            try
            {
                if (superintendenteRegionalId == Guid.Empty) return BadRequest($"Erro na alteração do cidade");

                var paraRemover = await _superintendenteRegionalService.Remover(superintendenteRegionalId);

                var menssagem = "Removido com sucesso!";

                return Json(new
                {
                    id = superintendenteRegionalId,
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
