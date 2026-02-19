using Microsoft.AspNetCore.Mvc;
using WEB.Helpers.Builder.Filtro;
using WEB.Helpers.Messages;
using WEB.Models.ViewModels;
using WEB.Models.ViewModels.Filtro;
using WEB.Services;
using WEB.Services.Interfaces;

namespace WEB.Controllers
{
    public class MembroController : Controller
    {
        private readonly IMembroService _membroService;
        private readonly IRegiaoService _regiaoService;
        private readonly ISuperintendenteEstadualService _superintendenteEstadualService;
        private readonly ISuperintendenteRegionalService _superintendenteRegionalService;
        private readonly IIgrejaService _igrejaService;
        private readonly IPastoresService _pastoresService;

        public MembroController(IMembroService membroService, IRegiaoService regiaoService, ISuperintendenteEstadualService superintendenteEstadualService, ISuperintendenteRegionalService superintendenteRegionalService, IIgrejaService igrejaService, IPastoresService pastoresService)
        {
            _membroService = membroService;
            _regiaoService = regiaoService;
            _superintendenteEstadualService = superintendenteEstadualService;
            _superintendenteRegionalService = superintendenteRegionalService;
            _igrejaService = igrejaService;
            _pastoresService = pastoresService;
        }

        public async Task<IActionResult> Index(FiltroMembroVm filtroMembroVm, int pagina = 1)
        {
            filtroMembroVm.Search = filtroMembroVm.Search ?? string.Empty;
            var filtroFinal = FiltroMembroBuilder.Construir(filtroMembroVm);

            var (lista, count) = await _membroService.GetAllPaginationAsync(filtroFinal, (pagina - 1) * 5);
            int numeroTotalPaginas = (int)Math.Ceiling(count / (double)5);
            pagina = Math.Clamp(pagina, 0, numeroTotalPaginas);


            ViewBag.FiltroMembro = filtroMembroVm;
            ViewBag.NumeroTotalPaginas = numeroTotalPaginas;
            ViewBag.PaginaAtual = pagina;
            ViewBag.TotalRegistro = count;
            ViewBag.TotalExibido = (await _membroService.GetAllAsync()).Count();
            return View(lista);
        }

        public async Task<IActionResult> Detalhe(Guid? membroId)
        {
            var detalhe = await _membroService.GetByIdAsync(membroId.Value);
            return PartialView("_Detalhe", detalhe);
        }

        public async Task<IActionResult> Operacao(Guid? membroId)
        {
            if (membroId == null)
                return NotFound();

            var item = await _membroService.GetByIdAsync(membroId.Value);

            if (item.Ativo)
            {
                await _membroService.InativarAsync(membroId.Value);
                TempData["success"] = "Obreiro inativado e tempo de ministério congelado!";
            }
            else
            {
                await _membroService.ReativarAsync(membroId.Value);
                TempData["success"] = "Obreiro reativado! Tempo de ministério voltou a contar.";
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Cadastrar(Guid? membroId)
        {
            var novo = new MembroVm();
            if (membroId != null) novo = await _membroService.GetByIdAsync(membroId.Value);

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
            ViewBag.Title = membroId != null ? "Editar" : "Cadastrar";

            return PartialView("_Cadastrar", novo);
        }          

        [HttpPost]
        public async Task<IActionResult> AlterarMembro(MembroVm vm)
        {
            string mensagemSucesso;

            // Salva foto de perfil
            if (vm.Foto != null)
            {
                var pasta = Path.Combine("wwwroot", "images", "membro", "perfil");

                if (!Directory.Exists(pasta))
                    Directory.CreateDirectory(pasta);

                var nomeArquivo = vm.NomeCompleto + Path.GetExtension(vm.Foto.FileName);
                var caminhoCompleto = Path.Combine(pasta, nomeArquivo);

                using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    await vm.Foto.CopyToAsync(stream);
                }

                vm.FotoUrl = "/images/membro/perfil/" + nomeArquivo;
            }

            // Verifica se já existe
            var existente = await _membroService.GetByIdAsync(vm.MembroId);

            if (existente != null)
            {
                await _membroService.UpdateAsync(vm);
                mensagemSucesso = "Edição realizada com sucesso!";
            }
            else
            {
                await _membroService.AddAsync(vm);
                mensagemSucesso = "Cadastro realizado com sucesso!";
            }

            return RedirectToAction("Index", "Membro").Success(mensagemSucesso);
        }
    }
}
