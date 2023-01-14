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

namespace UniSozluk.Controllers
{
    [AllowAnonymous]
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

        public IActionResult EntryListAll()//userin tüm entryleri
        {
            var values = em.GetListWithUniversityByUser(1);
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
            var entry = em.GetEntryWithUniversityandUserAndDepartmantByID(id);

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
        public IActionResult EntryEdit(Entry entry)//userin tüm entryleri
        {
            entry.EntryCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            em.TUpdate(entry);

            return RedirectToAction("EntryListAll");
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
            //var user = usm.TGetById(1);
            //var university = um.GetUniversityByUser(user);
            //ViewBag.u = university;

            var user = usm.GetUserWithUniversityByID(1);
            ViewBag.university = user.Departmant.University.UniversityName.ToString();


            List<SelectListItem> depValue = ((List<SelectListItem>)(from x in dm.GetListByUniversity(user.Departmant.University.UniversityID)
                                                                    select new SelectListItem
                                                                    {
                                                                        Text = x.DepartmantName,
                                                                        Value = x.DepartmantID.ToString(),

                                                                    }).ToList());
            ViewBag.depValue = depValue;

            List<SelectListItem> depValue2 = ((List<SelectListItem>)(from x in usm.GetUserListWithUniversityByID(1)
                                                                     select new SelectListItem
                                                                     {
                                                                         Text = x.Departmant.University.UniversityName,
                                                                         Value = x.DepartmantID.ToString(),

                                                                     }).ToList());

            ViewBag.depValue2= depValue2;

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
                e.EntryCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
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
