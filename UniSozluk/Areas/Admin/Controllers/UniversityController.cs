using BussinesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace UniSozluk.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class UniversityController : Controller
    {
        UniversityManager um = new UniversityManager(new EfUniversityRepository());
        public IActionResult Index(int page=1)
        {
            
            var values = um.GetList().ToPagedList(page,25);
            return View(values);
        }
    }
}
