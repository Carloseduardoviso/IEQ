using Microsoft.AspNetCore.Mvc;
using WEB.Models.Enuns;
using WEB.Services.Interfaces;

namespace WEB.Controllers
{
    public class CoordenadorController : Controller
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

        public CoordenadorController(IDiaconatoService diaconatoService, ILouvorService louvorService, IDancaService dancaService, IJovemAdolescenteService jovemAdolescenteService, IHomensService homensService, IMulheresService mulheresService, IMidiaService midiaService, ICriancaService criancaService, ITeatroService teatroService, ICasalService casalService)
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

            var diaconatos = await _diaconatoService.GetAllAsync(x => x.CargoRegional == CargoRegional.CoordenadorRegionalDiaconato);
            lista.AddRange(diaconatos.Select(x => new { Nome = x.NomeCompleto, Ministerio = "Diaconato", Igreja = x.Igreja?.Nome, Regiao = x.Regiao?.Nome, CargoRegional = x.CargoRegional }));

            return View(lista);
        }
    }
}
