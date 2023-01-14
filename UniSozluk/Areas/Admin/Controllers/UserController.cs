﻿using BussinesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace UniSozluk.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class UserController : Controller
    {
        UserManager usm = new UserManager(new EfUserRepository());
        DepartmantManager dm = new DepartmantManager(new EfDepartmantRepository());
        public IActionResult Index(int page = 1)
        {
            var values = usm.GetUsersWithDepartmantAndEntries().ToPagedList(page, 25);
            return View(values);
        }

        [HttpGet]
        public IActionResult UserEdit(int id)
        {
            List<SelectListItem> DepartmantValue = (from x in usm.GetUsersWithDepartmantAndEntries()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Departmant.DepartmantName,
                                                        Value = x.DepartmantID.ToString()
                                                    }
                                                    ).ToList();
            ViewBag.depValue = DepartmantValue;

            var value = usm.GetUserWithUniversityByID(id);

            return View(value);
        }

        [HttpPost]
        public IActionResult UserEdit(User user)//userin tüm entryleri
        {
            
            user.UserStatus = true;
            user.UserID = 1;
            usm.TUpdate(user);

            return RedirectToAction("Index");
        }

        public IActionResult EntryDelete(int id)//userin tüm entryleri
        {
            var value = usm.TGetById(id);
            usm.TDelete(value);
            return RedirectToAction("EntryListAll");
        }
    }
}
