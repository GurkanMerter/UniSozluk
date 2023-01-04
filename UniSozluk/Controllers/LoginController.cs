using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace UniSozluk.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(User user)
        {
            Context context = new Context();
            var check = context.Users.FirstOrDefault(x=>x.UserMail==user.UserMail && x.UserPassword==user.UserPassword);
            if (check != null)
            {
                //Talep oluşturacağız
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserMail)
                };
                var useridentity = new ClaimsIdentity(claims,"a");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);

                //HttpContext.Session.SetString("UserMail", user.UserMail);         //session seviyesinde 
                
                return RedirectToAction("MainPage", "Entry");
            }
            else
            {
                return View();
            }
            
            
        }
    }
}
