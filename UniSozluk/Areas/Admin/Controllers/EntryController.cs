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
    [AllowAnonymous]
    [Area("Admin")]
    public class EntryController : Controller
    {
        EntryManager em = new EntryManager(new EfEntryRepository());
        public IActionResult Index()
        {
            var values = em.GetEntryListWithDepartmant();

            return View(values);
        }

        [HttpGet]
        public IActionResult EntryEdit(int id)
        {
            List<SelectListItem> DepartmantValue = (from x in em.GetListWithDepartmantByUserID(id)
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Departmant.DepartmantName,
                                                        Value = x.DepartmantID.ToString()
                                                    }
                                                    ).ToList();
            ViewBag.depValue = DepartmantValue;

            var value = em.GetEntryWithUniversityByID(id);

            return View(value);
        }

        [HttpPost]
        public IActionResult EntryEdit(Entry entry)//userin tüm entryleri
        {
            entry.EntryCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            entry.EntryStatus = true;
            entry.UserID = 1;
            em.TUpdate(entry);

            return RedirectToAction("Index");
        }

        public IActionResult EntryDelete(int id)//userin tüm entryleri
        {
            var value = em.TGetById(id);
            em.TDelete(value);
            return RedirectToAction("EntryListAll");
        }
    }
}
