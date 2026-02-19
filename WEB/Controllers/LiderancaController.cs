using Microsoft.AspNetCore.Mvc;
using WEB.Models.Enuns;
using WEB.Services.Interfaces;

namespace WEB.Controllers
{
    public class LiderancaController : Controller
    {
        private readonly IDiaconatoService _diaconatoService;
        private readonly ILouvorService _louvorService;
        private readonly IDancaService _dancaService;
        private readonly IJovemAdolescenteService _jovemAdolescenteService;
        private readonly IHomensService _homensService;
        private readonly IMulheresService _mulheresService;
        private readonly IMidiaService _midiaService;
        private readonly ICriancaService _criancaService;
        private readonly ITeatroService _teatroService;
        private readonly ICasalService _casalService;

        public LiderancaController(IDiaconatoService diaconatoService, ILouvorService louvorService, IDancaService dancaService, IJovemAdolescenteService jovemAdolescenteService, IHomensService homensService, IMulheresService mulheresService, IMidiaService midiaService, ICriancaService criancaService, ITeatroService teatroService, ICasalService casalService)
        {
            _diaconatoService = diaconatoService;
            _louvorService = louvorService;
            _dancaService = dancaService;
            _jovemAdolescenteService = jovemAdolescenteService;
            _homensService = homensService;
            _mulheresService = mulheresService;
            _midiaService = midiaService;
            _criancaService = criancaService;
            _teatroService = teatroService;
            _casalService = casalService;
        }

        public async Task<IActionResult> Index()
        {
            var lista = new List<dynamic>();

            var diaconatos = await _diaconatoService.GetAllAsync(x => x.CargoLocal == CargoLocal.Diretor || x.CargoLocal == CargoLocal.Diretora);
            lista.AddRange(diaconatos.Select(x => new { FotoUrl = x.FotoUrl, Nome = x.NomeCompleto, Ministerio = "Diaconato", Igreja = x.Igreja?.Nome, Regiao = x.Regiao?.Nome, CargoLocal = x.CargoLocal }));

            var louvores = await _louvorService.GetAllAsync(x => x.CargoLocal == CargoLocal.Lider || x.CargoLocal == CargoLocal.ViceLider);
            lista.AddRange(louvores.Select(x => new { FotoUrl = x.FotoUrl, Nome = x.NomeCompleto, Ministerio = "Louvor", Igreja = x.Igreja?.Nome, Regiao = x.Regiao?.Nome, CargoLocal = x.CargoLocal }));

            var dancas = await _dancaService.GetAllAsync(x => x.CargoLocal == CargoLocal.Lider || x.CargoLocal == CargoLocal.ViceLider);
            lista.AddRange(dancas.Select(x => new { FotoUrl = x.FotoUrl, Nome = x.NomeCompleto, Ministerio = "Dança", Igreja = x.Igreja?.Nome, Regiao = x.Regiao?.Nome, CargoLocal = x.CargoLocal }));

            var jovensAdolescentes = await _jovemAdolescenteService.GetAllAsync(x => x.CargoLocal == CargoLocal.Lider || x.CargoLocal == CargoLocal.ViceLider);
            lista.AddRange(jovensAdolescentes.Select(x => new { FotoUrl = x.FotoUrl, Nome = x.NomeCompleto, Ministerio = "Jovem/Adolescente", Igreja = x.Igreja?.Nome, Regiao = x.Regiao?.Nome, CargoLocal = x.CargoLocal }));

            var homens = await _homensService.GetAllAsync(x => x.CargoLocal == CargoLocal.Lider || x.CargoLocal == CargoLocal.ViceLider);
            lista.AddRange(homens.Select(x => new { FotoUrl = x.FotoUrl, Nome = x.NomeCompleto, Ministerio = "Homens", Igreja = x.Igreja?.Nome, Regiao = x.Regiao?.Nome, CargoLocal = x.CargoLocal }));

            var mulheres = await _mulheresService.GetAllAsync(x => x.CargoLocal == CargoLocal.Lider || x.CargoLocal == CargoLocal.ViceLider);
            lista.AddRange(mulheres.Select(x => new { FotoUrl = x.FotoUrl, Nome = x.NomeCompleto, Ministerio = "Mulheres", Igreja = x.Igreja?.Nome, Regiao = x.Regiao?.Nome, CargoLocal = x.CargoLocal }));

            var midias = await _midiaService.GetAllAsync(x => x.CargoLocal == CargoLocal.Lider || x.CargoLocal == CargoLocal.ViceLider);
            lista.AddRange(midias.Select(x => new { FotoUrl = x.FotoUrl, Nome = x.NomeCompleto, Ministerio = "Mídia", Igreja = x.Igreja?.Nome, Regiao = x.Regiao?.Nome, CargoLocal = x.CargoLocal }));

            var criancas = await _criancaService.GetAllAsync(x => x.CargoLocal == CargoLocal.Lider || x.CargoLocal == CargoLocal.ViceLider);
            lista.AddRange(criancas.Select(x => new { FotoUrl = x.FotoUrl, Nome = x.NomeCompleto, Ministerio = "Crianças", Igreja = x.Igreja?.Nome, Regiao = x.Regiao?.Nome, CargoLocal = x.CargoLocal }));

            var teatros = await _teatroService.GetAllAsync(x => x.CargoLocal == CargoLocal.Lider || x.CargoLocal == CargoLocal.ViceLider);
            lista.AddRange(teatros.Select(x => new { FotoUrl = x.FotoUrl, Nome = x.NomeCompleto, Ministerio = "Teatro", Igreja = x.Igreja?.Nome, Regiao = x.Regiao?.Nome, CargoLocal = x.CargoLocal }));

            var casais = await _casalService.GetAllAsync(x => x.CargoLocal == CargoLocal.Lider || x.CargoLocal == CargoLocal.ViceLider);
            lista.AddRange(casais.Select(x => new { FotoUrl = x.FotoUrl, Nome = x.NomeCompleto, Ministerio = "Casal", Igreja = x.Igreja?.Nome, Regiao = x.Regiao?.Nome, CargoLocal = x.CargoLocal }));

            return View(lista);
        }
    }
}