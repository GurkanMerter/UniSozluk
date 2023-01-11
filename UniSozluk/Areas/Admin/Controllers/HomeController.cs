using Microsoft.AspNetCore.Mvc;

namespace UniSozluk.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
