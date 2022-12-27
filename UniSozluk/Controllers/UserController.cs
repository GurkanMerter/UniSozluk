using Microsoft.AspNetCore.Mvc;

namespace UniSozluk.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
