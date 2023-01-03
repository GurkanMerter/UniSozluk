using Microsoft.AspNetCore.Mvc;

namespace UniSozluk.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
