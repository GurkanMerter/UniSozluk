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

        EntryManager em = new EntryManager(new EfEntryRepository());
        UniversityManager um = new UniversityManager(new EfUniversityRepository());
        DepartmantManager dm = new DepartmantManager(new EfDepartmantRepository());
        PersonManager usm = new PersonManager(new EfPersonRepository());
        Context context = new Context();


        public IActionResult MainPage()
        {
            //sisteme authantica olmuş kullanıcıya göre veri gerişi yapmak istiyorum;
            var username = User.Identity.Name;
            ViewBag.v = username;
            var usermail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var personid = context.Persons.Where(x => x.PersonMail == usermail).Select(y => y.PersonID).FirstOrDefault();
            var values = em.GetEntryListWithDepartmant();

            return View(values);
        }

        public IActionResult EntryListAll()//Personin tüm entryleri
        {
            var values = em.GetListWithUniversityByPerson(1);
            return View(values);
        }


        public IActionResult EntryDelete(int id)//Personin tüm entryleri
        {
            var value = em.TGetById(id);
            em.TDelete(value);
            return RedirectToAction("EntryListAll");
        }


        [HttpGet]
        public IActionResult EntryEdit(int id)//Personin tüm entryleri
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
            var username = User.Identity.Name;
            var usermail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var personID = context.Persons.Where(x => x.PersonMail == usermail).Select(y => y.PersonID).FirstOrDefault();
            //var personUni = context.Persons.Where(x => x.PersonID == personID).Select(y => y.Departmant.UniversityID).FirstOrDefault().Value;

            entry.EntryCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            entry.EntryStatus = true;
            entry.PersonID = personID;
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
            //var Person = usm.TGetById(1);
            //var university = um.GetUniversityByPerson(Person);
            //ViewBag.u = university;

            var Person = usm.GetPersonWithUniversityByID(1);
            ViewBag.university = Person.Departmant.University.UniversityName.ToString();


            List<SelectListItem> depValue = ((List<SelectListItem>)(from x in dm.GetListByUniversity(Person.Departmant.University.UniversityID) //universityıd
                                                                    select new SelectListItem
                                                                    {
                                                                        Text = x.DepartmantName,
                                                                        Value = x.DepartmantID.ToString(),

                                                                    }).ToList());
            ViewBag.depValue = depValue;

            List<SelectListItem> depValue2 = ((List<SelectListItem>)(from x in usm.GetPersonListWithUniversityByID(1) //personıd
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
            var username = User.Identity.Name;
            var usermail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var personID = context.Persons.Where(x => x.PersonMail == usermail).Select(y => y.PersonID).FirstOrDefault();

            EntryValidation ev = new EntryValidation();
            ValidationResult result = ev.Validate(e);

            if (result.IsValid)
            {
                e.EntryStatus = true;
                e.EntryCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                e.PersonID = personID;
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
