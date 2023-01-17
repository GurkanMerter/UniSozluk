using BussinesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace UniSozluk.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class UniversityController : Controller
    {
        UniversityManager um = new UniversityManager(new EfUniversityRepository());
        DepartmantManager dm = new DepartmantManager(new EfDepartmantRepository());
        public IActionResult Index(int page=1)
        {
            
            var values = um.GetUniversitiesWithDepartmants().ToPagedList(page,25);
            return View(values);
        }

        [HttpGet]
        public IActionResult UniversityEdit(int id)
        {
            var university = um.TGetById(id);


            List<SelectListItem> DepartmantValue = (from x in dm.GetListByUniversityID(university.UniversityID)
                                                    select new SelectListItem
                                                    {
                                                        Text = x.DepartmantName,
                                                        Value = x.DepartmantID.ToString()
                                                    }
                                                    ).ToList();
            ViewBag.depValue = DepartmantValue;

           // var value = usm.GetPersonWithUniversityByID(id);

            return View(university);
        }

        [HttpPost]
        public IActionResult UniversityEdit(University uni)
        {

            um.TUpdate(uni);

            return RedirectToAction("Index");
        }

        public IActionResult UniversityDelete(int id)
        {
            var value = um.TGetById(id);
            um.TDelete(value);
            return RedirectToAction("Index");
        }

    }
}
