using Microsoft.AspNetCore.Mvc;
using WEB.Models.ViewModels;
using WEB.Services.Interfaces;

namespace WEB.Controllers
{
    public class IgrejaController : Controller
    {
        private readonly IIgrejaService _igrejaService;

        public IgrejaController(IIgrejaService igrejaService)
        {
            _igrejaService = igrejaService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Cadastrar(Guid? igrejaId)
        {
            var novo = new IgrejaVm();
            if (igrejaId != null) novo = await _igrejaService.GetByIdAsync(igrejaId.Value);

            ViewBag.Title = igrejaId != null ? "Editar" : "Cadastrar";

            return PartialView("_Cadastrar", novo);
        }
    }
}
