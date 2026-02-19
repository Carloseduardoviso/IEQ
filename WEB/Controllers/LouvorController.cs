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
    public class LouvorController : Controller
    {
        private readonly ILouvorService _louvorService;
        private readonly IRegiaoService _regiaoService;
        private readonly ISuperintendenteEstadualService _superintendenteEstadualService;
        private readonly ISuperintendenteRegionalService _superintendenteRegionalService;
        private readonly IIgrejaService _igrejaService;
        private readonly IPastoresService _pastoresService;

        public LouvorController(ILouvorService louvorService, IRegiaoService regiaoService, ISuperintendenteEstadualService superintendenteEstadualService, ISuperintendenteRegionalService superintendenteRegionalService, IIgrejaService igrejaService, IPastoresService pastoresService)
        {
            _louvorService = louvorService;
            _regiaoService = regiaoService;
            _superintendenteEstadualService = superintendenteEstadualService;
            _superintendenteRegionalService = superintendenteRegionalService;
            _igrejaService = igrejaService;
            _pastoresService = pastoresService;
        }   

        public async Task<IActionResult> Index(FiltroLouvorVm filtroLouvorVm, int pagina = 1)
        {
            filtroLouvorVm.Search = filtroLouvorVm.Search ?? string.Empty;
            var filtroFinal = FiltroLouvorBuilder.Construir(filtroLouvorVm);

            var (lista, count) = await _louvorService.GetAllPaginationAsync(filtroFinal, (pagina - 1) * 5);
            int numeroTotalPaginas = (int)Math.Ceiling(count / (double)5);
            pagina = Math.Clamp(pagina, 0, numeroTotalPaginas);

            ViewBag.FiltroLouvor = filtroLouvorVm;
            ViewBag.NumeroTotalPaginas = numeroTotalPaginas;
            ViewBag.PaginaAtual = pagina;
            ViewBag.TotalRegistro = count;
            ViewBag.TotalExibido = (await _louvorService.GetAllAsync()).Count();
            return View(lista);
        }

        public async Task<IActionResult> Detalhe(Guid? louvorId)
        {
            var detalhe = await _louvorService.GetByIdAsync(louvorId.Value);
            return PartialView("_Detalhe", detalhe);
        }

        public async Task<IActionResult> Operacao(Guid? louvorId)
        {
            if (louvorId == null)
                return NotFound();

            var item = await _louvorService.GetByIdAsync(louvorId.Value);

            if (item.Ativo)
            {
                await _louvorService.InativarAsync(louvorId.Value);
                TempData["success"] = "Obreiro inativado e tempo de ministério congelado!";
            }
            else
            {
                await _louvorService.ReativarAsync(louvorId.Value);
                TempData["success"] = "Obreiro reativado! Tempo de ministério voltou a contar.";
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Cadastrar(Guid?louvorId)
        {
            var novo = new LouvorVm();
            if (louvorId != null) novo = await _louvorService.GetByIdAsync(louvorId.Value);

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
            ViewBag.Title = louvorId != null ? "Editar" : "Cadastrar";

            return PartialView("_Cadastrar", novo);
        }
  
        [HttpPost]
        public async Task<IActionResult> AlterarLouvor(LouvorVm vm)
        {
            string mensagemSucesso;

            // Salva foto de perfil
            if (vm.Foto != null)
            {
                var pasta = Path.Combine("wwwroot", "images", "louvor", "perfil");

                if (!Directory.Exists(pasta))
                    Directory.CreateDirectory(pasta);

                var nomeArquivo = vm.NomeCompleto + Path.GetExtension(vm.Foto.FileName);
                var caminhoCompleto = Path.Combine(pasta, nomeArquivo);

                using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    await vm.Foto.CopyToAsync(stream);
                }

                vm.FotoUrl = "/images/louvor/perfil/" + nomeArquivo;
            }

            // Verifica se já existe
            var existente = await _louvorService.GetByIdAsync(vm.LouvorId);

            if (existente != null)
            {
                await _louvorService.UpdateAsync(vm);
                mensagemSucesso = "Edição realizada com sucesso!";
            }
            else
            {
                await _louvorService.AddAsync(vm);
                mensagemSucesso = "Cadastro realizado com sucesso!";
            }

            return RedirectToAction("Index", "Louvor").Success(mensagemSucesso);
        }
    }
}
