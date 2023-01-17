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
        public async Task<IActionResult> Index(Person Person)
        {
            Context context = new Context();
            var check = context.Persons.FirstOrDefault(x=>x.PersonMail==Person.PersonMail && x.PersonPassword==Person.PersonPassword);
            if (check != null)
            {
                //Talep oluşturacağız
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,Person.PersonMail)
                };
                var Personidentity = new ClaimsIdentity(claims,"a");
                ClaimsPrincipal principal = new ClaimsPrincipal(Personidentity);
                await HttpContext.SignInAsync(principal);

                //HttpContext.Session.SetString("PersonMail", Person.PersonMail);         //session seviyesinde 
                
                return RedirectToAction("MainPage", "Entry");
            }
            else
            {
                return View();
            }
            
            
        }
    }
}
