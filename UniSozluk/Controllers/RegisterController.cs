using BussinesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace UniSozluk.Controllers
{
    public class RegisterController : Controller
    {
        UserManager um = new UserManager(new EfUserRepository());
        UniversityManager unim = new UniversityManager(new EfUniversityRepository()); 

        [HttpGet]
        public IActionResult Index()
        {
            var values=unim.GetList();
            return View(values);
        }

        public JsonResult GetDepartmant(int id)
        {

            List<SelectListItem> Departmant = unim.GetList(id).Select(n =>
                  new SelectListItem
                  {
                      Value = n.UniversityID.ToString(),
                      Text = n.UniversityName.ToString()
                  }).ToList();

            

            return Json(Departmant);
        }

        [HttpPost]
        public IActionResult Index(User user)
        {

            user.DepartmantID = 1;
            user.UserStatus = true;
            um.TAdd(user);
            return RedirectToAction("MainPage","Entry");
        
        }


    }
}
