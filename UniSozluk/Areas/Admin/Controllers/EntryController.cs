using BussinesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UniSozluk.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class EntryController : Controller
    {
        EntryManager em = new EntryManager(new EfEntryRepository());
        DepartmantManager dm = new DepartmantManager(new EfDepartmantRepository());
        public IActionResult Index()
        {
            var values = em.GetEntryListWithDepartmant().Where(x=>x.EntryStatus==true);

            return View(values);
        }

        public IActionResult EntryApproval()
        {
            var values = em.GetEntryListWithDepartmant().Where(x=>x.EntryStatus==false);

            return View(values);
        }

        public IActionResult EntryApprove(int id)
        {
            var entry = em.TGetById(id);
            entry.EntryStatus= true;
            em.TUpdate(entry);

            return RedirectToAction("EntryApproval");
       }

        [HttpGet]
        public IActionResult EntryEdit(int id)
        {
            var entry = em.GetEntryWithUniversityandPersonAndDepartmantByID(id);

            List<SelectListItem> DepartmantValue = (from x in dm.GetListByUniversityID(entry.Departmant.University.UniversityID)
                                                    select new SelectListItem
                                                    {
                                                        Text = x.DepartmantName,
                                                        Value = x.DepartmantID.ToString()
                                                    }
                                                    ).ToList();
            ViewBag.depValue = DepartmantValue;

            var value = em.GetEntryWithUniversityByID(id);

            return View(value);
        }

        [HttpPost]
        public IActionResult EntryEdit(Entry entry)//Personin tüm entryleri
        {
            entry.EntryCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            entry.EntryStatus = true;
            entry.PersonID = 1;
            em.TUpdate(entry);

            return RedirectToAction("Index");
        }

        public IActionResult EntryDelete(int id)//Personin tüm entryleri
        {
            var value = em.TGetById(id);
            em.TDelete(value);
            return RedirectToAction("INDEX");
        }
    }
}
