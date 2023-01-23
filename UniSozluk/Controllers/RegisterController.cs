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
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        PersonManager um = new PersonManager(new EfPersonRepository());
        UniversityManager unim = new UniversityManager(new EfUniversityRepository()); 
        DepartmantManager dm = new DepartmantManager(new EfDepartmantRepository());

        
        [HttpGet]
        public IActionResult Index()
        {
            var values=unim.GetList();
            return View(values);
        }


        
        [HttpPost]
        public IActionResult Index(Person Person)
        {
            Person.PersonStatus = true;
            um.TAdd(Person);
            return RedirectToAction("MainPage","Entry");
        
        }

        
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
