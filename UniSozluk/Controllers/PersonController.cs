using BussinesLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniSozluk.Models;

namespace UniSozluk.Controllers
{
    
    public class PersonController : Controller
    {
        PersonManager pm = new PersonManager(new EfPersonRepository());
        DepartmantManager dm = new DepartmantManager(new EfDepartmantRepository());
        Context context = new Context();
        UserManager um = new UserManager(new EfUserRepository());
        private readonly UserManager<AppUser> _userManager;

        public PersonController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        [Authorize(Roles = "Admin,Person")]
        public IActionResult Index(int id)
        {

            var username = User.Identity.Name;
            var usermail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var personID = context.Users.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            ViewBag.val = username;
            var personName = context.Persons.Where(x => x.PersonMail == usermail).Select(y => y.PersonFirstName).FirstOrDefault();
            ViewBag.name = personName;

            var value = pm.GetPersonWithDepartmantAndUniversity(id);
            ViewBag.universityEntryCount = context.Entries.Where(x => x.Departmant.University.UniversityID == value.Departmant.University.UniversityID).Count();
           
            return View(value);
        }

        [Authorize(Roles = "Admin,Person")]
        [HttpGet]
        public async Task<IActionResult> PersonEdit()
        {
            

            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel();
            model.mail = value.Email;
            model.name = value.FirstName;
            model.surname = value.LastName;
            model.nickname = value.UserName;
           

            return View(model);
        }

        [Authorize(Roles = "Admin,Person")]
        [HttpPost]
        public async Task<IActionResult> PersonEdit(UserUpdateViewModel model)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            model.mail = values.Email;
            model.name = values.FirstName;
            model.surname = values.LastName;
            model.nickname = values.UserName;
            var passwordHash = _userManager.PasswordHasher.HashPassword(values, model.password);
            var result = await _userManager.UpdateAsync(values);

            return RedirectToAction("Index");
        }

        



    }
}
