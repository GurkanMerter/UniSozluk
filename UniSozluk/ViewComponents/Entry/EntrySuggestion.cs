using BussinesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace UniSozluk.ViewComponents.Entry
{
    public class EntrySuggestion:ViewComponent
    {
        EntryManager em = new EntryManager(new EfEntryRepository());
        
        public IViewComponentResult Invoke()
        {
            var values = em.GetEntryListWithUniversityLast3Entry();

            return View(values);
        }

    }
}
