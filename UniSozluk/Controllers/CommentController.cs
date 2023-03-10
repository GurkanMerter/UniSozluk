using BussinesLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Linq;

namespace UniSozluk.Controllers
{
    public class CommentController : Controller
    {
        EntryManager em = new EntryManager(new EfEntryRepository());
        UniversityManager um = new UniversityManager(new EfUniversityRepository());
        DepartmantManager dm = new DepartmantManager(new EfDepartmantRepository());
        PersonManager pm = new PersonManager(new EfPersonRepository());
        UserManager userManager = new UserManager(new EfUserRepository());
        Context context = new Context();

        CommentManager cm = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin,Person")]
        [HttpGet]
        public PartialViewResult CommentAdd()
        {
           

            return PartialView();
        }
        [Authorize(Roles = "Admin,Person")]
        [HttpPost]
        public IActionResult CommentAdd(Comment com,int id)
        {
            var username = User.Identity.Name;
            var usermail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var personID = context.Persons.Where(x => x.PersonMail == usermail).Select(y => y.PersonID).FirstOrDefault();
            
            var commentEntryID = id;
            
            com.CommentDate=DateTime.Parse(DateTime.Now.ToShortDateString());
            com.CommentStatus = true;
            com.EntryID = commentEntryID;
            com.CommentPersonNickName = username;
            cm.TAdd(com);
            return RedirectToAction("Mainpage","Entry");
        }
    }
}
