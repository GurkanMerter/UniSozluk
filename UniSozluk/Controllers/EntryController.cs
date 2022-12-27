using BussinesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace UniSozluk.Controllers
{
    public class EntryController : Controller
    {
        EntryManager em = new EntryManager(new EfEntryRepository());
        //CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IActionResult MainPage()
        {
            var values = em.GetEntryListWithDepartmant();
            return View(values);
        }

        public IActionResult EntryListAll()//userin kendi entryleri
        {

            return View();
        }
        public IActionResult EntryReadAll(int id)
        {
            ViewBag.i = id; //gönderdiğimiz id'yi yazdırmak için;
            var values = em.GetEntryByID(id);
            return View(values);
        }

        [HttpGet]
        public IActionResult EntryAdd()
        {

            return View();
        }
    }
}
