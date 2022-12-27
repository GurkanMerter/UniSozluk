using Microsoft.AspNetCore.Mvc;

namespace UniSozluk.Controllers
{
    public class DepartmantController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
