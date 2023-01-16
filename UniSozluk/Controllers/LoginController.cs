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
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.username, user.password, false, true);
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
        //public async Task<IActionResult> Index(User user)
        //{
        //    Context context = new Context();
        //    var check = context.Users.FirstOrDefault(x=>x.UserMail==user.UserMail && x.UserPassword==user.UserPassword);
        //    if (check != null)
        //    {
        //        //Talep oluşturacağız
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name,user.UserMail)
        //        };
        //        var useridentity = new ClaimsIdentity(claims,"a");
        //        ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
        //        await HttpContext.SignInAsync(principal);

        //        //HttpContext.Session.SetString("UserMail", user.UserMail);         //session seviyesinde 
                
        //        return RedirectToAction("MainPage", "Entry");
        //    }
        //    else
        //    {
        //        return View();
        //    }
            
            
        //}
    }
}
