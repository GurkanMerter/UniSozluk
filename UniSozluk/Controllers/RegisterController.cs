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
        DepartmantManager dm = new DepartmantManager(new EfDepartmantRepository());

        [HttpGet]
        public IActionResult Index()
        {
            var values=unim.GetList();
            return View(values);
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
