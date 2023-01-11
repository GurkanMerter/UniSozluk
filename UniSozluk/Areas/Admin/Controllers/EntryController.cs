using BussinesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UniSozluk.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class EntryController : Controller
    {
        EntryManager em = new EntryManager(new EfEntryRepository());
        public IActionResult Index()
        {
            var values = em.GetList();

            return View(values);
        }
    }
}
