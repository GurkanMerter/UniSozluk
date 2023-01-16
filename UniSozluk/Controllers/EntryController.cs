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
using Microsoft.AspNetCore.Authorization;
using DataAccessLayer.Concrete;

namespace UniSozluk.Controllers
{
    [AllowAnonymous]
    public class EntryController : Controller
    {
        Context context = new Context();    
        EntryManager em = new EntryManager(new EfEntryRepository());
        UniversityManager um = new UniversityManager(new EfUniversityRepository());
        DepartmantManager dm = new DepartmantManager(new EfDepartmantRepository());
        PersonManager usm = new PersonManager(new EfPersonRepository());

        [AllowAnonymous]
        public IActionResult MainPage()
        {
            //sisteme authantica olmuş kullanıcıya göre veri gerişi yapmak istiyorum;
            var username = User.Identity.Name;
            ViewBag.v = username;
            //var usermail = context.User.Where(x =>x.);

            var values = em.GetEntryListWithDepartmant();
            return View(values);
        }
       
        public IActionResult EntryListAll()//userin tüm entryleri
        {
            var values = em.GetListWithUniversityByPerson(1);
            return View(values);
        } 
        

        public IActionResult EntryDelete(int id)//userin tüm entryleri
        {
            var value = em.TGetById(id);
            em.TDelete(value);
            return RedirectToAction("EntryListAll");
        } 
        

        [HttpGet]
        public IActionResult EntryEdit(int id)//userin tüm entryleri
        {
            List<SelectListItem> DepartmantValue = (from x in em.GetEntryListWithDepartmant()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Departmant.DepartmantName,
                                                        Value = x.DepartmantID.ToString()
                                                    }
                                                    ).ToList();
            ViewBag.depValue = DepartmantValue;

            var value = em.TGetById(id);

            return View(value);
        } 

        [HttpPost]
        public IActionResult EntryEdit(Entry entry)//userin tüm entryleri
        {
            entry.EntryCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            entry.EntryStatus = true ;
            entry.PersonID = 1;
            em.TUpdate(entry);
            
            return RedirectToAction("EntryListAll");
        }

        [AllowAnonymous]
        public IActionResult EntryReadAll(int id)
        {
            ViewBag.i = id; //gönderdiğimiz id'yi yazdırmak için;
            var values = em.GetEntryByID(id);
            return View(values);
        }

        [HttpGet]
        public IActionResult EntryAdd()
        {
            //var user = usm.TGetById(1);
            //var university = um.GetUniversityByUser(user);
            //ViewBag.u = university;

            var user = usm.GetListWithUniversity(1);
            ViewBag.university = user.Departmant.University.UniversityName.ToString();

            List<SelectListItem> depValue = ((List<SelectListItem>)(from x in dm.GetListByUniversity(user.Departmant.University.UniversityID) select new SelectListItem
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
                e.PersonID = 1;
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
