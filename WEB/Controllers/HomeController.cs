using Microsoft.AspNetCore.Mvc;
using WEB.Services.Interfaces;

public class HomeController : Controller
{
    private readonly IDiaconatoService _diaconatoService;

    public HomeController(IDiaconatoService diaconatoService)
    {
        _diaconatoService = diaconatoService;
    }

    public async Task<IActionResult> Index()
    {
        var todosDiaconatos = await _diaconatoService.GetAllAsync();
        return View(todosDiaconatos); // envia para a view Home/Index
    }

    // Partial dos aniversariantes
    public async Task<IActionResult> Aniversariantes()
    {
        var todos = await _diaconatoService.GetAllAsync();
        return PartialView("_Aniversariantes", todos);
    }
}
