using BussinesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace UniSozluk.Controllers
{
    public class RegisterController : Controller
    {
        PersonManager um = new PersonManager(new EfPersonRepository());
        UniversityManager unim = new UniversityManager(new EfUniversityRepository()); 
        DepartmantManager dm = new DepartmantManager(new EfDepartmantRepository());

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            var values=unim.GetList();
            return View(values);
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult Index(Person person)
        {
            person.PersonStatus = true;
            um.TAdd(person);
            return RedirectToAction("MainPage","Entry");
        
        }

        [AllowAnonymous]
        public JsonResult GetDepartmantList(int id)
        {
            List<SelectListItem> Departmant = dm.GetListByUniversity(id).OrderBy(x=>x.DepartmantName).Select(x =>
            new SelectListItem
            {
                Value = x.DepartmantID.ToString(),
                Text = x.DepartmantName.ToString()
            }).ToList();

            return Json(Departmant);
        }


    }
}
