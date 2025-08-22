using Microsoft.AspNetCore.Mvc;
using WEB.Helpers.Messages;
using WEB.Models.ViewModels;
using WEB.Services.Interfaces;

namespace WEB.Controllers
{
    public class DiaconatoController : Controller
    {
        public readonly IDiaconatoService _diaconatoService;

        public DiaconatoController(IDiaconatoService diaconatoService)
        {
            _diaconatoService = diaconatoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Cadastrar(Guid? diaconatoId)
        {
            var novo = new DiaconatoVm();
            if (diaconatoId != null) novo = await _diaconatoService.GetByIdAsync(diaconatoId.Value);

            ViewBag.Title = diaconatoId != null ? "Editar" : "Cadastrar";

            return PartialView("_Cadastrar", novo);
        }

        [HttpPost]
        public async Task<IActionResult> AlterarAsync(DiaconatoVm diaconatoVm)
        {
            string mensagemSucess = "";
            var novo = await _diaconatoService.GetByIdAsync(diaconatoVm.DiaconatoId);

            if (novo != null)
            {
                await _diaconatoService.UpdateAsync(diaconatoVm);
                mensagemSucess = "Edição de cliente, efetuado com sucesso!";

            }
            else
            {
                await _diaconatoService.AddAsync(diaconatoVm);
                mensagemSucess = "Cadastro de cliente, efetuado com sucesso!";
            }

            return RedirectToAction("Index", "Diaconato").Success(mensagemSucess);
        }
    }
}
