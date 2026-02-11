using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    public class HomensController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
