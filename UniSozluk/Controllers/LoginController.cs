using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UniSozluk.Models;

namespace UniSozluk.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        private readonly UserManager<AppUser> _userManager;

        private readonly RoleManager<AppRole> _roleManager;

        private IConfiguration _config;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
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
                var loginUser= await _userManager.FindByNameAsync(user.usernickname);
                var result = await _signInManager.PasswordSignInAsync(user.usernickname, user.password, false, true);
                //overload -> persistent,çerezlerde hatırlasın mı?
                //overload-> lockoutOnFailure, kişinin authantice olurken hatalı girişte sistem bir süre banlansın 
                if (result.Succeeded)
                {
                    HttpContext.Session.SetString("Id", loginUser.Id.ToString());
                    HttpContext.Session.SetString("NickName", loginUser.UserName);
                    HttpContext.Session.SetString("Token", GenerateJwtToken(loginUser));
                    return RedirectToAction("MainPage", "Entry");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }

            return View();
        }

        private string GenerateJwtToken(AppUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("2023EncodingKeyUniSozluk");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                    new Claim(ClaimTypes.Name,user.UserName)

                }),
                Expires = DateTime.UtcNow.AddDays(1),  //token bir gün geçerli
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }


        public async Task<ActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }

        

    }
}
