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
    public class PersonController : Controller
    {
        PersonManager usm = new PersonManager(new EfPersonRepository());
        DepartmantManager dm = new DepartmantManager(new EfDepartmantRepository());
        Context context = new Context();

        [HttpGet]
        public IActionResult Index(int id)
        {
            var value = usm.GetPersonWithDepartmantAndUniversity(id);
            ViewBag.universityEntryCount = context.Entries.Where(x => x.Departmant.University.UniversityID == value.Departmant.University.UniversityID).Count();
            ViewBag.PersonEntryCount = context.Entries.Where(x=>x.PersonID == id).Count();
            return View(value);
        }

        [HttpGet]
        public IActionResult PersonEdit(int id)
        {
            var Person = usm.GetPersonWithUniversityByID(id);


            List<SelectListItem> DepartmantValue = (from x in dm.GetListByUniversityID((int)Person.Departmant.UniversityID)
                                                    select new SelectListItem
                                                    {
                                                        Text = x.DepartmantName,
                                                        Value = x.DepartmantID.ToString()
                                                    }
                                                    ).ToList();
            ViewBag.depValue = DepartmantValue;

            return View(Person);
        }

        [HttpPost]
        public IActionResult PersonEdit(Person Person)
        {
            usm.TUpdate(Person);
            return RedirectToAction("Index");
        }



        
    }
}
