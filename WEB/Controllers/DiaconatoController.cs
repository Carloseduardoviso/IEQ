using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using WEB.Helpers.Builder.Filtro;
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

        public async Task<IActionResult> Index(FiltroDiaconatoVm filtroDiaconatoVm, int pagina = 1)
        {
            filtroDiaconatoVm.Search = NormalizeSearch(filtroDiaconatoVm.Search ?? string.Empty);
            var filtroFinal = FiltroDiaconatoBuilder.Construir(filtroDiaconatoVm);

            var (lista, count) = await _diaconatoService.GetAllPaginationAsync(filtroFinal, (pagina - 1) * 5);
            int numeroTotalPaginas = (int)Math.Ceiling(count / (double)5);
            pagina = Math.Clamp(pagina, 0, numeroTotalPaginas);



            ViewBag.FiltroDiaconato = filtroDiaconatoVm;
            ViewBag.NumeroTotalPaginas = numeroTotalPaginas;
            ViewBag.PaginaAtual = pagina;
            ViewBag.TotalRegistro = count;
            ViewBag.TotalExibido = (await _diaconatoService.GetAllAsync()).Count();
            return View(lista);
        }

        public async Task<IActionResult> Detalhe(Guid? diaconatoId)
        {
            var detalhe = await _diaconatoService.GetByIdAsync(diaconatoId.Value);
            return PartialView("_Detalhe", detalhe);
        }

        public async Task<IActionResult> ObreiroAtivo(Guid? diaconatoId)
        {
            if (diaconatoId == null)
                return NotFound();

            var item = await _diaconatoService.GetByIdAsync(diaconatoId.Value);

            if (item.Ativo)
            {
                await _diaconatoService.InativarAsync(diaconatoId.Value);
                TempData["success"] = "Obreiro inativado e tempo de ministério congelado!";
            }
            else
            {
                await _diaconatoService.ReativarAsync(diaconatoId.Value);
                TempData["success"] = "Obreiro reativado! Tempo de ministério voltou a contar.";
            }

            return RedirectToAction(nameof(Index));
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

                var nomeArquivo = vm.NomeCompleto + Path.GetExtension(vm.Foto.FileName);
                var caminhoCompleto = Path.Combine(pasta, nomeArquivo);

                using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    await vm.Foto.CopyToAsync(stream);
                }

                vm.FotoUrl = "/images/diaconato/perfil/" + nomeArquivo;
            }

            if (vm.FotoConsagracao != null)
            {
                var pasta = Path.Combine("wwwroot", "images", "diaconato", "certificados", "consagracao");

                if (!Directory.Exists(pasta))
                    Directory.CreateDirectory(pasta);

                var name = vm.NomeCompleto?.Trim() + "_Consagracao";

                var extensao = Path.GetExtension(vm.FotoConsagracao.FileName);
                if (string.IsNullOrEmpty(extensao))
                    extensao = ".png";

                var nomeArquivo = name + extensao;

                var caminhoCompleto = Path.Combine(pasta, nomeArquivo);

                using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    await vm.FotoConsagracao.CopyToAsync(stream);
                }

                vm.FotoUrlConsagracao = "/images/diaconato/certificados/consagracao/" + nomeArquivo;
            }

            if (vm.Foto5Anos != null)
            {
                var pasta = Path.Combine("wwwroot", "images", "diaconato", "certificados", "5anos");

                if (!Directory.Exists(pasta))
                    Directory.CreateDirectory(pasta);

                var name = vm.NomeCompleto?.Trim() + "_5anos";

                var extensao = Path.GetExtension(vm.Foto5Anos!.FileName);
                if (string.IsNullOrEmpty(extensao))
                    extensao = ".png";

                var nomeArquivo = name + extensao;

                var caminhoCompleto = Path.Combine(pasta, nomeArquivo);

                using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    await vm.Foto5Anos.CopyToAsync(stream);
                }

                vm.FotoUrl5Anos = "/images/diaconato/certificados/5anos/" + nomeArquivo;
            }

            if (vm.Foto10Anos != null)
            {
                var pasta = Path.Combine("wwwroot", "images", "diaconato", "certificados", "10anos");

                if (!Directory.Exists(pasta))
                    Directory.CreateDirectory(pasta);

                var name = vm.NomeCompleto?.Trim() + "_10anos";

                var extensao = Path.GetExtension(vm.Foto10Anos!.FileName);
                if (string.IsNullOrEmpty(extensao))
                    extensao = ".png";

                var nomeArquivo = name + extensao;

                var caminhoCompleto = Path.Combine(pasta, nomeArquivo);

                using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    await vm.Foto10Anos.CopyToAsync(stream);
                }

                vm.FotoUrl10Anos = "/images/diaconato/certificados/10anos/" + nomeArquivo;
            }

            if (vm.Foto15Anos != null)
            {
                var pasta = Path.Combine("wwwroot", "images", "diaconato", "certificados", "15anos");

                if (!Directory.Exists(pasta))
                    Directory.CreateDirectory(pasta);

                var name = vm.NomeCompleto?.Trim() + "_15anos";

                var extensao = Path.GetExtension(vm.Foto15Anos!.FileName);
                if (string.IsNullOrEmpty(extensao))
                    extensao = ".png";

                var nomeArquivo = name + extensao;

                var caminhoCompleto = Path.Combine(pasta, nomeArquivo);

                using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    await vm.Foto15Anos.CopyToAsync(stream);
                }

                vm.FotoUrl15Anos = "/images/diaconato/certificados/15anos/" + nomeArquivo;
            }

            if (vm.Foto20Anos != null)
            {
                var pasta = Path.Combine("wwwroot", "images", "diaconato", "certificados", "20anos");

                if (!Directory.Exists(pasta))
                    Directory.CreateDirectory(pasta);

                var name = vm.NomeCompleto?.Trim() + "_20anos";

                var extensao = Path.GetExtension(vm.Foto5Anos!.FileName);
                if (string.IsNullOrEmpty(extensao))
                    extensao = ".png";

                var nomeArquivo = name + extensao;

                var caminhoCompleto = Path.Combine(pasta, nomeArquivo);

                using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    await vm.Foto20Anos.CopyToAsync(stream);
                }

                vm.FotoUrl20Anos = "/images/diaconato/certificados/20anos/" + nomeArquivo;
            }

            if (vm.Foto25Anos != null)
            {
                var pasta = Path.Combine("wwwroot", "images", "diaconato", "certificados", "25anos");

                if (!Directory.Exists(pasta))
                    Directory.CreateDirectory(pasta);

                var name = vm.NomeCompleto?.Trim() + "_25anos";

                var extensao = Path.GetExtension(vm.Foto25Anos!.FileName);
                if (string.IsNullOrEmpty(extensao))
                    extensao = ".png";

                var nomeArquivo = name + extensao;

                var caminhoCompleto = Path.Combine(pasta, nomeArquivo);

                using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    await vm.Foto25Anos.CopyToAsync(stream);
                }

                vm.FotoUrl25Anos = "/images/diaconato/certificados/25anos/" + nomeArquivo;
            }

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

        private string NormalizeSearch(string search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return string.Empty;

            // Remove acentos
            search = RemoverAcentos(search);

            // Remove espaços duplicados
            search = Regex.Replace(search, @"\s+", " ");

            // Remove espaços no início e no fim
            search = search.Trim();

            return search;
        }

        private string RemoverAcentos(string texto)
        {
            return new string(
                texto
                    .Normalize(NormalizationForm.FormD)
                    .Where(ch => CharUnicodeInfo.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                    .ToArray()
            ).Normalize(NormalizationForm.FormC);
        }

    }
}