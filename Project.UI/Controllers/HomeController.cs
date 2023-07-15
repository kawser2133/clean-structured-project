using Microsoft.AspNetCore.Mvc;

namespace Project.UI.Controllers
{
    public class HomeController : Controller
    {
        //Dashboard Page
        public IActionResult Index()
        {
            return View();
        }
    }
}
