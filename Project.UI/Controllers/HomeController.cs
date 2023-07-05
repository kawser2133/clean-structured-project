using Microsoft.AspNetCore.Mvc;

namespace Project.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
