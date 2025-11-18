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

        public async Task<IActionResult> Detalhe(Guid? diaconatoId)
        {
            var detalhe = await _diaconatoService.GetByIdAsync(diaconatoId.Value);
            return PartialView("_Detalhe", detalhe);
        }     

        public async Task<IActionResult> Cadastrar(Guid? diaconatoId)
        {
            var novo = new DiaconatoVm();
            if (diaconatoId != null) novo = await _diaconatoService.GetByIdAsync(diaconatoId.Value);

            ViewBag.Title = diaconatoId != null ? "Editar" : "Cadastrar";

            return PartialView("_Cadastrar", novo);
        }

        [HttpPost]
        public async Task<IActionResult> AlterarDiaconato(DiaconatoVm vm)
        {
            string mensagemSucesso;

            // Salva foto de perfil
            if (vm.Foto != null)
            {
                var pasta = Path.Combine("wwwroot", "images", "diaconato", "perfil");

                if (!Directory.Exists(pasta))
                    Directory.CreateDirectory(pasta);

                var nomeArquivo = Guid.NewGuid() + Path.GetExtension(vm.Foto.FileName);
                var caminhoCompleto = Path.Combine(pasta, nomeArquivo);

                using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    await vm.Foto.CopyToAsync(stream);
                }

                vm.FotoUrl = "/images/diaconato/perfil/" + nomeArquivo;
            }
            //vm.FotoUrl = await SalvarArquivoPerfil(vm.Foto!, "perfil");

            // Salva certificados (cada um com seu próprio arquivo)
            vm.FotoUrlConsagracao = await SalvarArquivo(vm.FotoConsagracao!, "certificados");
            vm.FotoUrl5Anos = await SalvarArquivo(vm.Foto5Anos!, "certificados");
            vm.FotoUrl10Anos = await SalvarArquivo(vm.Foto10Anos!, "certificados");
            vm.FotoUrl15Anos = await SalvarArquivo(vm.Foto15Anos!, "certificados");
            vm.FotoUrl20Anos = await SalvarArquivo(vm.Foto20Anos!, "certificados");
            vm.FotoUrl25Anos = await SalvarArquivo(vm.Foto25Anos!, "certificados");

            // Verifica se já existe
            var existente = await _diaconatoService.GetByIdAsync(vm.DiaconatoId);

            if (existente != null)
            {
                await _diaconatoService.UpdateAsync(vm);
                mensagemSucesso = "Edição realizada com sucesso!";
            }
            else
            {
                await _diaconatoService.AddAsync(vm);
                mensagemSucesso = "Cadastro realizado com sucesso!";
            }

            return RedirectToAction("Index", "Diaconato").Success(mensagemSucesso);
        }



        private async Task<string> SalvarArquivo(IFormFile arquivo, string pastaDestino)
        {
            if (arquivo == null) return null;

            var pasta = Path.Combine("wwwroot", "images", "diaconato", pastaDestino);

            if (!Directory.Exists(pasta))
                Directory.CreateDirectory(pasta);

            var nomeArquivo = Guid.NewGuid() + Path.GetExtension(arquivo.FileName);
            var caminhoCompleto = Path.Combine(pasta, nomeArquivo);

            using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }

            return $"/images/diaconato/{pastaDestino}/{nomeArquivo}";
        }
    }
}