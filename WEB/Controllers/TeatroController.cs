using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    public class TeatroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
