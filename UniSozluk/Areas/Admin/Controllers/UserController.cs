using BussinesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace UniSozluk.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class UserController : Controller
    {
        UserManager usm = new UserManager(new EfUserRepository());
        public IActionResult Index(int page = 1)
        {
            var values = usm.GetList().ToPagedList(page, 25);
            return View(values);
        }
    }
}
