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

        public async Task<IActionResult> Index()
        {
            var buscaTodos = await _diaconatoService.GetAllAsync();
            return View(buscaTodos);
        }

        public async Task<IActionResult> Cadastrar(Guid? diaconatoId)
        {
            var novo = new DiaconatoVm();
            if (diaconatoId != null) novo = await _diaconatoService.GetByIdAsync(diaconatoId.Value);

            ViewBag.Title = diaconatoId != null ? "Editar" : "Cadastrar";

            return PartialView("_Cadastrar", novo);
        }

        [HttpPost]
        public async Task<IActionResult> AlterarDiaconato(DiaconatoVm diaconatoVm)
        {
            string mensagemSucess = "";
          
            if (diaconatoVm.Foto != null)
            {
                var pasta = Path.Combine("wwwroot", "images", "diaconato");

                if (!Directory.Exists(pasta))
                    Directory.CreateDirectory(pasta);

                var nomeArquivo = Guid.NewGuid() + Path.GetExtension(diaconatoVm.Foto.FileName);
                var caminhoCompleto = Path.Combine(pasta, nomeArquivo);

                using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    await diaconatoVm.Foto.CopyToAsync(stream);
                }

                diaconatoVm.FotoUrl = "/images/diaconato/" + nomeArquivo;
            }

            var existente = await _diaconatoService.GetByIdAsync(diaconatoVm.DiaconatoId);

            if (existente != null)
            {
                await _diaconatoService.UpdateAsync(diaconatoVm);
                mensagemSucess = "Edição de cliente efetuada com sucesso!";
            }
            else
            {
                await _diaconatoService.AddAsync(diaconatoVm);
                mensagemSucess = "Cadastro de cliente efetuado com sucesso!";
            }

            return RedirectToAction("Index", "Diaconato").Success(mensagemSucess);
        }
    }
}