﻿using BussinesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace UniSozluk.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class DashboardController : Controller
    {
        EntryManager em = new EntryManager(new EfEntryRepository());
        UniversityManager um = new UniversityManager(new EfUniversityRepository()); 
        UserManager usm = new UserManager(new EfUserRepository()); 
        DepartmantManager dm = new DepartmantManager(new EfDepartmantRepository()); 
      
        public IActionResult Index()
        {
            var values = em.GetListWithUser();
            var values2 = um.GetList();
            var values3 = usm.GetList();
            var values4 = dm.GetList();
            
          
            ViewBag.entryCount = values.Count();
            ViewBag.universityCount = values2.Count();
            ViewBag.userCount = values3.Count();
            ViewBag.departmantCount = values4.Count();
            return View(values);
        }
    }
}