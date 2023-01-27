using BussinesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace UniSozluk.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PersonController : Controller
    {
        PersonManager usm = new PersonManager(new EfPersonRepository());
        DepartmantManager dm = new DepartmantManager(new EfDepartmantRepository());
        private readonly UserManager<AppUser> _userManager;
        public IActionResult Index(int page = 1)
        {
            var values = usm.GetPersonsWithDepartmantAndEntries().ToPagedList(page, 25);
            return View(values);
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

            var value = usm.GetPersonWithUniversityByID(id);

            return View(value);
        }

        [HttpPost]
        public IActionResult PersonEdit(Person Person)
        {
 
            usm.TUpdate(Person);
            return RedirectToAction("Index");
        }

        public IActionResult PersonDelete(int id)
        {
            var value = usm.TGetById(id);
            usm.TDelete(value); 
            var user = _userManager.Users.Where(x=>x.Id== id).FirstOrDefault();
            _userManager.DeleteAsync(user);
            return RedirectToAction("Index");
        }
    }
}
