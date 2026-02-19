using Microsoft.AspNetCore.Mvc;
using WEB.Helpers.Builder.Filtro;
using WEB.Helpers.Messages;
using WEB.Models.ViewModels;
using WEB.Models.ViewModels.Filtro;
using WEB.Services;
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

        public async Task<IActionResult> Index(FiltroCriancaVm filtroCriancaVm, int pagina = 1)
        {
            filtroCriancaVm.Search = filtroCriancaVm.Search ?? string.Empty;
            var filtroFinal = FiltroCriancaBuilder.Construir(filtroCriancaVm);

            var (lista, count) = await _criancaService.GetAllPaginationAsync(filtroFinal, (pagina - 1) * 5);
            int numeroTotalPaginas = (int)Math.Ceiling(count / (double)5);
            pagina = Math.Clamp(pagina, 0, numeroTotalPaginas);


            ViewBag.FiltroCrianca = filtroCriancaVm;
            ViewBag.NumeroTotalPaginas = numeroTotalPaginas;
            ViewBag.PaginaAtual = pagina;
            ViewBag.TotalRegistro = count;
            ViewBag.TotalExibido = (await _criancaService.GetAllAsync()).Count();
            return View(lista);
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
            string mensagemSucesso;

            // Salva foto de perfil
            if (vm.Foto != null)
            {
                var pasta = Path.Combine("wwwroot", "images", "crianca", "perfil");

                if (!Directory.Exists(pasta))
                    Directory.CreateDirectory(pasta);

                var nomeArquivo = vm.NomeCompleto + Path.GetExtension(vm.Foto.FileName);
                var caminhoCompleto = Path.Combine(pasta, nomeArquivo);

                using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    await vm.Foto.CopyToAsync(stream);
                }

                vm.FotoUrl = "/images/crianca/perfil/" + nomeArquivo;
            }

            // Verifica se já existe
            var existente = await _criancaService.GetByIdAsync(vm.CriancaId);

            if (existente != null)
            {
                await _criancaService.UpdateAsync(vm);
                mensagemSucesso = "Edição realizada com sucesso!";
            }
            else
            {
                await _criancaService.AddAsync(vm);
                mensagemSucesso = "Cadastro realizado com sucesso!";
            }

            return RedirectToAction("Index", "Crianca").Success(mensagemSucesso);
        }
    }
}