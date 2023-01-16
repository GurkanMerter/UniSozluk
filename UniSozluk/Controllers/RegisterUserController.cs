using BussinesLayer.Concrete;
using DataAccessLayer;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UniSozluk.Models;

namespace UniSozluk.Controllers
{
    [AllowAnonymous]
    public class RegisterUserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterUserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel u)
        {
            if(ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    Email = u.Mail,
                    UserName = u.UserName,
                    NameSurname = u.NameSurname,
                    University = u.University,
                };
                var result = await _userManager.CreateAsync(user,u.Password);


                if(result.Succeeded)
                {
                    return RedirectToAction("Index","Login");   
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
    }
}
