using BussinesLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace UniSozluk.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        UserManager usm = new UserManager(new EfUserRepository());
        Context context = new Context();

        [HttpGet]
        public IActionResult Index(int id)
        {
            var value = usm.GetUserWithDepartmantAndUniversity(id);
            ViewBag.universityEntryCount = context.Entries.Where(x => x.Departmant.University.UniversityID == value.Departmant.University.UniversityID).Count();
            ViewBag.userEntryCount = context.Entries.Where(x=>x.UserID == id).Count();
            return View(value);
        }
    }
}
