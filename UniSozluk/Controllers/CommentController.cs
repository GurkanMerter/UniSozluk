﻿using BussinesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace UniSozluk.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public PartialViewResult CommentAdd()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult CommentAdd(Comment com)
        {
            com.CommentDate=DateTime.Parse(DateTime.Now.ToShortDateString());
            com.CommentStatus = true;
            //com.EntryID = 1;
            cm.TAdd(com);
            return RedirectToAction("Mainpage","Entry");
        }
    }
}
