using BussinesLayer.Concrete;
using BussinesLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Collections.Generic;

namespace UniSozluk.Controllers
{
    public class EntryController : Controller
    {
        
        EntryManager em = new EntryManager(new EfEntryRepository());
        UniversityManager um = new UniversityManager(new EfUniversityRepository());
        DepartmantManager dm = new DepartmantManager(new EfDepartmantRepository());
        UserManager usm = new UserManager(new EfUserRepository());

        
        public IActionResult MainPage()
        {
            var values = em.GetEntryListWithDepartmant();
            return View(values);
        }

        public IActionResult EntryListAll()//userin kendi entryleri
        {

            return View();
        }
        public IActionResult EntryReadAll(int id)
        {
            ViewBag.i = id; //gönderdiğimiz id'yi yazdırmak için;
            var values = em.GetEntryByID(id);
            return View(values);
        }



        [HttpGet]
        public IActionResult EntryAdd()
        {
            
            List<SelectListItem> depValue = ((List<SelectListItem>)(from x in dm.GetListByUniversity(1) select new SelectListItem
            {
                Text=x.DepartmantName,
                Value=x.DepartmantID.ToString(),
                
            }).ToList());
            ViewBag.depValue = depValue;

            
            return View();
        }
        
        [HttpPost]
        public IActionResult EntryAdd(Entry e)
        {
            EntryValidation ev = new EntryValidation();
            ValidationResult result = ev.Validate(e);

            if (result.IsValid)
            {
                e.EntryStatus = true;
                e.EntryCreateDate= DateTime.Parse(DateTime.Now.ToShortDateString());
                e.UserID = 1;
                em.TAdd(e);
                return RedirectToAction("EntryListAll", "Entry");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }
    }
}
