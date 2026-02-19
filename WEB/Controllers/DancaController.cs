using Microsoft.AspNetCore.Mvc;
using WEB.Helpers.Builder.Filtro;
using WEB.Helpers.Messages;
using WEB.Models.ViewModels;
using WEB.Models.ViewModels.Filtro;
using WEB.Services;
using WEB.Services.Interfaces;

namespace WEB.Controllers
{
    public class DancaController : Controller
    {
        private readonly IDancaService _dancaService;
        private readonly IRegiaoService _regiaoService;
        private readonly ISuperintendenteEstadualService _superintendenteEstadualService;
        private readonly ISuperintendenteRegionalService _superintendenteRegionalService;
        private readonly IIgrejaService _igrejaService;
        private readonly IPastoresService _pastoresService;

        public DancaController(IDancaService dancaService, IRegiaoService regiaoService, ISuperintendenteEstadualService superintendenteEstadualService, ISuperintendenteRegionalService superintendenteRegionalService, IIgrejaService igrejaService, IPastoresService pastoresService)
        {
            _dancaService = dancaService;
            _regiaoService = regiaoService;
            _superintendenteEstadualService = superintendenteEstadualService;
            _superintendenteRegionalService = superintendenteRegionalService;
            _igrejaService = igrejaService;
            _pastoresService = pastoresService;
        }

        public async Task<IActionResult> Index(FiltroDancaVm filtroDancaVm, int pagina = 1)
        {
            filtroDancaVm.Search = filtroDancaVm.Search ?? string.Empty;
            var filtroFinal = FiltroDancaBuilder.Construir(filtroDancaVm);

            var (lista, count) = await _dancaService.GetAllPaginationAsync(filtroFinal, (pagina - 1) * 5);
            int numeroTotalPaginas = (int)Math.Ceiling(count / (double)5);
            pagina = Math.Clamp(pagina, 0, numeroTotalPaginas);


            ViewBag.FiltroDanca = filtroDancaVm;
            ViewBag.NumeroTotalPaginas = numeroTotalPaginas;
            ViewBag.PaginaAtual = pagina;
            ViewBag.TotalRegistro = count;
            ViewBag.TotalExibido = (await _dancaService.GetAllAsync()).Count();
            return View(lista);
        }

        public async Task<IActionResult> Detalhe(Guid? dancaId)
        {
            var detalhe = await _dancaService.GetByIdAsync(dancaId.Value);
            return PartialView("_Detalhe", detalhe);
        }

        public async Task<IActionResult> Operacao(Guid? dancaId)
        {
            if (dancaId == null)
                return NotFound();

            var item = await _dancaService.GetByIdAsync(dancaId.Value);

            if (item.Ativo)
            {
                await _dancaService.InativarAsync(dancaId.Value);
                TempData["success"] = "Obreiro inativado e tempo de ministério congelado!";
            }
            else
            {
                await _dancaService.ReativarAsync(dancaId.Value);
                TempData["success"] = "Obreiro reativado! Tempo de ministério voltou a contar.";
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Cadastrar(Guid? dancaId)
        {
            var novo = new DancaVm();
            if (dancaId != null) novo = await _dancaService.GetByIdAsync(dancaId.Value);

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
            ViewBag.Title = dancaId != null ? "Editar" : "Cadastrar";

            return PartialView("_Cadastrar", novo);
        }      

        [HttpPost]
        public async Task<IActionResult> AlterarIgreja(DancaVm vm)
        {
            string mensagemSucesso;

            // Salva foto de perfil
            if (vm.Foto != null)
            {
                var pasta = Path.Combine("wwwroot", "images", "danca", "perfil");

                if (!Directory.Exists(pasta))
                    Directory.CreateDirectory(pasta);

                var nomeArquivo = vm.NomeCompleto + Path.GetExtension(vm.Foto.FileName);
                var caminhoCompleto = Path.Combine(pasta, nomeArquivo);

                using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    await vm.Foto.CopyToAsync(stream);
                }

                vm.FotoUrl = "/images/danca/perfil/" + nomeArquivo;
            }

            // Verifica se já existe
            var existente = await _dancaService.GetByIdAsync(vm.DancaId);

            if (existente != null)
            {
                await _dancaService.UpdateAsync(vm);
                mensagemSucesso = "Edição realizada com sucesso!";
            }
            else
            {
                await _dancaService.AddAsync(vm);
                mensagemSucesso = "Cadastro realizado com sucesso!";
            }

            return RedirectToAction("Index", "Danca").Success(mensagemSucesso);
        }
    }
}
