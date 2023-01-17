using BussinesLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace UniSozluk.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        UserManager usm = new UserManager(new EfUserRepository());
        DepartmantManager dm = new DepartmantManager(new EfDepartmantRepository());
        Context context = new Context();

        [HttpGet]
        public IActionResult Index(int id)
        {
            var value = usm.GetUserWithDepartmantAndUniversity(id);
            ViewBag.universityEntryCount = context.Entries.Where(x => x.Departmant.University.UniversityID == value.Departmant.University.UniversityID).Count();
            ViewBag.userEntryCount = context.Entries.Where(x=>x.UserID == id).Count();
            return View(value);
        }

        [HttpGet]
        public IActionResult UserEdit(int id)
        {
            var user = usm.GetUserWithUniversityByID(id);


            List<SelectListItem> DepartmantValue = (from x in dm.GetListByUniversityID((int)user.Departmant.UniversityID)
                                                    select new SelectListItem
                                                    {
                                                        Text = x.DepartmantName,
                                                        Value = x.DepartmantID.ToString()
                                                    }
                                                    ).ToList();
            ViewBag.depValue = DepartmantValue;

            return View(user);
        }

        [HttpPost]
        public IActionResult UserEdit(User user)
        {
            usm.TUpdate(user);
            return RedirectToAction("Index");
        }



        
    }
}
