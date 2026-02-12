using Microsoft.AspNetCore.Mvc;
using WEB.Models.Enuns;
using WEB.Services.Interfaces;

namespace WEB.Controllers
{
    public class LiderancaController : Controller
    {
        private readonly IDiaconatoService _diaconatoService;
        private readonly ICriancaService _criancaService;
        private readonly IHomensService homensService;
        private readonly IJovemAdolescenteService jovemAdolescenteService;
        private readonly ILouvorService louvorService;
        private readonly IMidiaService midiaService;
        private readonly IMulheresService mulheresService;
        private readonly ITeatroService teatroService ;

        public LiderancaController(IDiaconatoService diaconatoService, ICriancaService criancaService, IHomensService homensService, IJovemAdolescenteService jovemAdolescenteService, ILouvorService louvorService, IMidiaService midiaService, IMulheresService mulheresService, ITeatroService teatroService)
        {
            _diaconatoService = diaconatoService;
            _criancaService = criancaService;
            this.homensService = homensService;
            this.jovemAdolescenteService = jovemAdolescenteService;
            this.louvorService = louvorService;
            this.midiaService = midiaService;
            this.mulheresService = mulheresService;
            this.teatroService = teatroService;
        }

        public async Task<IActionResult> Index()
        {
            var lista = new List<dynamic>();

            var diaconatos = await _diaconatoService.GetAllAsync(x => x.CargoLocal == CargoLocal.Diretor || x.CargoLocal == CargoLocal.Diretora || x.CargoRegional == CargoRegional.CoordenadorRegionalDiaconato);

            lista.AddRange(diaconatos.Select(x => new {
                Nome = x.NomeCompleto,
                Ministerio = "Diaconato",
                Igreja = x.Igreja?.Nome,
                Regiao = x.Regiao?.Nome,
                Cargo = x.CargoLocal.ToString()
            }));

            //var criancas = await _criancaService.GetAllAsync(...);

            //lista.AddRange(criancas.Select(x => new {
            //    Nome = x.Nome,
            //    Ministerio = "Crianças",
            //    Cargo = x.CargoLocal.ToString()
            //}));

            return View(lista);
        }
    }
}
