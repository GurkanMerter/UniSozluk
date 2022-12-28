﻿using BussinesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace UniSozluk.Controllers
{
    public class RegisterController : Controller
    {
        UserManager um = new UserManager(new EfUserRepository());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User user)
        {

            user.DepartmantID = 1;
            user.UserStatus = true;
            um.TAdd(user);
            return RedirectToAction("MainPage","Entry");
        
        }


    }
}