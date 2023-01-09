using BussinesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UniSozluk.Controllers
{
    [AllowAnonymous]
    public class UniversityController : Controller
    {
        UniversityManager um = new UniversityManager(new EfUniversityRepository());
        EntryManager em = new EntryManager(new EfEntryRepository());


        public IActionResult Index()
        {
            var values = um.GetList();
            return View(values);
        }

        public IActionResult UniversityEntryPage(int id)
        {
            var values = em.GetListWithDepartmantsByUniversity(id);
            return View(values);
        }

        
    }
}
