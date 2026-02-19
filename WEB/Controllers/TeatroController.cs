using Microsoft.AspNetCore.Mvc;
using WEB.Helpers.Builder.Filtro;
using WEB.Helpers.Messages;
using WEB.Models.Entities;
using WEB.Models.ViewModels;
using WEB.Models.ViewModels.Filtro;
using WEB.Services;
using WEB.Services.Interfaces;

namespace WEB.Controllers
{
    public class TeatroController : Controller
    {
        private readonly ITeatroService _teatroService;
        private readonly IRegiaoService _regiaoService;
        private readonly ISuperintendenteEstadualService _superintendenteEstadualService;
        private readonly ISuperintendenteRegionalService _superintendenteRegionalService;
        private readonly IIgrejaService _igrejaService;
        private readonly IPastoresService _pastoresService;

        public TeatroController(ITeatroService teatroService, IRegiaoService regiaoService, ISuperintendenteEstadualService superintendenteEstadualService, ISuperintendenteRegionalService superintendenteRegionalService, IIgrejaService igrejaService, IPastoresService pastoresService)
        {
            _teatroService = teatroService;
            _regiaoService = regiaoService;
            _superintendenteEstadualService = superintendenteEstadualService;
            _superintendenteRegionalService = superintendenteRegionalService;
            _igrejaService = igrejaService;
            _pastoresService = pastoresService;
        }

        public async Task<IActionResult> Index(FiltroTeatroVm filtroTeatroVm, int pagina = 1)
        {
            filtroTeatroVm.Search = filtroTeatroVm.Search ?? string.Empty;
            var filtroFinal = FiltroTeatroBuilder.Construir(filtroTeatroVm);

            var (lista, count) = await _teatroService.GetAllPaginationAsync(filtroFinal, (pagina - 1) * 5);
            int numeroTotalPaginas = (int)Math.Ceiling(count / (double)5);
            pagina = Math.Clamp(pagina, 0, numeroTotalPaginas);


            ViewBag.FiltroTeatro = filtroTeatroVm;
            ViewBag.NumeroTotalPaginas = numeroTotalPaginas;
            ViewBag.PaginaAtual = pagina;
            ViewBag.TotalRegistro = count;
            ViewBag.TotalExibido = (await _teatroService.GetAllAsync()).Count();
            return View(lista);
        }

        public async Task<IActionResult> Detalhe(Guid? teatroId)
        {
            var detalhe = await _teatroService.GetByIdAsync(teatroId.Value);
            return PartialView("_Detalhe", detalhe);
        }

        public async Task<IActionResult> Operacao(Guid? teatroId)
        {
            if (teatroId == null)
                return NotFound();

            var item = await _teatroService.GetByIdAsync(teatroId.Value);

            if (item.Ativo)
            {
                await _teatroService.InativarAsync(teatroId.Value);
                TempData["success"] = "Obreiro inativado e tempo de ministério congelado!";
            }
            else
            {
                await _teatroService.ReativarAsync(teatroId.Value);
                TempData["success"] = "Obreiro reativado! Tempo de ministério voltou a contar.";
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Cadastrar(Guid? teatroId)
        {
            var novo = new TeatroVm();
            if (teatroId != null) novo = await _teatroService.GetByIdAsync(teatroId.Value);

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
            ViewBag.Title = teatroId != null ? "Editar" : "Cadastrar";

            return PartialView("_Cadastrar", novo);
        }

        [HttpPost]
        public async Task<IActionResult> AlterarTeatro(TeatroVm vm)
        {
            string mensagemSucesso;

            // Salva foto de perfil
            if (vm.Foto != null)
            {
                var pasta = Path.Combine("wwwroot", "images", "teatro", "perfil");

                if (!Directory.Exists(pasta))
                    Directory.CreateDirectory(pasta);

                var nomeArquivo = vm.NomeCompleto + Path.GetExtension(vm.Foto.FileName);
                var caminhoCompleto = Path.Combine(pasta, nomeArquivo);

                using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    await vm.Foto.CopyToAsync(stream);
                }

                vm.FotoUrl = "/images/teatro/perfil/" + nomeArquivo;
            }

            // Verifica se já existe
            var existente = await _teatroService.GetByIdAsync(vm.TeatroId);

            if (existente != null)
            {
                await _teatroService.UpdateAsync(vm);
                mensagemSucesso = "Edição realizada com sucesso!";
            }
            else
            {
                await _teatroService.AddAsync(vm);
                mensagemSucesso = "Cadastro realizado com sucesso!";
            }

            return RedirectToAction("Index", "Teatro").Success(mensagemSucesso);
        }
    }
}
