using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UniSozluk.Models;

namespace UniSozluk.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.usernickname, user.password, false, true);
                //overload -> persistent,çerezlerde hatırlasın mı?
                //overload-> lockoutOnFailure, kişinin authantice olurken hatalı girişte sistem bir süre banlansın 
                if (result.Succeeded)
                {
                    return RedirectToAction("MainPage", "Entry");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }

            return View();
        }


        //[HttpPost]
        //[AllowAnonymous]
        //public async Task<IActionResult> Index(Person Person)
        //{
        //    Context context = new Context();
        //    var check = context.Persons.FirstOrDefault(x=>x.PersonMail==Person.PersonMail && x.PersonPassword==Person.PersonPassword);
        //    if (check != null)
        //    {
        //        //Talep oluşturacağız
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name,Person.PersonMail)
        //        };
        //        var Personidentity = new ClaimsIdentity(claims,"a");
        //        ClaimsPrincipal principal = new ClaimsPrincipal(Personidentity);
        //        await HttpContext.SignInAsync(principal);

        //        //HttpContext.Session.SetString("PersonMail", Person.PersonMail);         //session seviyesinde 

        //        return RedirectToAction("MainPage", "Entry");
        //    }
        //    else
        //    {
        //        return View();
        //    }


        //}
    }
}
