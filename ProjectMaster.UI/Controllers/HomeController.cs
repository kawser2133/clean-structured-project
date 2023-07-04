using Microsoft.AspNetCore.Mvc;

namespace ProjectMaster.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
