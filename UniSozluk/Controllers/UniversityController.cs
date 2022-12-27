using BussinesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace UniSozluk.Controllers
{
    public class UniversityController : Controller
    {
        UniversityManager universityManager = new UniversityManager(new EfUniversityRepository());
        public IActionResult Index()
        {
            var values = universityManager.GetList();
            return View(values);
        }
    }
}
