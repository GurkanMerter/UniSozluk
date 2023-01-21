using BussinesLayer.Concrete;
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
    [AllowAnonymous]
    public class RegisterUserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        DepartmantManager dm = new DepartmantManager(new EfDepartmantRepository());
        UniversityManager unim = new UniversityManager(new EfUniversityRepository());

        public RegisterUserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //List<SelectListItem> uniValue = ((List<SelectListItem>)(from x in unim.GetList() //universityıd
            //                                                        select new SelectListItem
            //                                                        {
            //                                                            Text = x.UniversityName,
            //                                                            Value = x.UniversityID.ToString(),

            //                                                        }).ToList());
            //ViewBag.depValue = uniValue;

            var a = new UserRegisterViewModel();
            a.Universities = unim.GetList();

            return View(a);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel u)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    Email = u.Mail,
                    UserName = u.NickName,
                    FirstName = u.FirsName,
                    LastName = u.LastName,
                    University = u.University,
                    Departmant = u.DepartmantID,
                };
                var result = await _userManager.CreateAsync(user, u.Password);


                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(u);
        }

        [AllowAnonymous]
        public JsonResult GetDepartmantList(int id)
        {
            List<SelectListItem> Departmant = dm.GetListByUniversity(id).OrderBy(x => x.DepartmantName).Select(x =>
              new SelectListItem
              {
                  Value = x.DepartmantID.ToString(),
                  Text = x.DepartmantName.ToString()
              }).ToList();


            return Json(Departmant);
        }
    }
}
