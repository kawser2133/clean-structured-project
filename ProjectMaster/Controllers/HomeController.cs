using Microsoft.AspNetCore.Mvc;

namespace ProjectMaster.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
