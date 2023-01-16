using BussinesLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace UniSozluk.Controllers
{
    [AllowAnonymous]
    public class PersonController : Controller
    {
        PersonManager usm = new PersonManager(new EfPersonRepository());
        Context context = new Context();

        [HttpGet]
        public IActionResult Index(int id)
        {
            var value = usm.GetPersonWithDepartmantAndUniversity(id);
            ViewBag.universityEntryCount = context.Entries.Where(x => x.Departmant.University.UniversityID == value.Departmant.University.UniversityID).Count();
            ViewBag.PersonEntryCount = context.Entries.Where(x=>x.PersonID == id).Count();
            return View(value);
        }
    }
}
