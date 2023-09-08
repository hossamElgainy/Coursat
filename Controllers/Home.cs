using Microsoft.AspNetCore.Mvc;

namespace Coursat.Controllers
{
    public class Home : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
