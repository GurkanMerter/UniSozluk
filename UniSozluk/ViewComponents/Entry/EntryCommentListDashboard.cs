using BussinesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace UniSozluk.ViewComponents.Entry
{
    public class EntryCommentListDashboard:ViewComponent
    {
        EntryManager em = new EntryManager(new EfEntryRepository());
        public IViewComponentResult Invoke()
        {
            var values = em.Get5WithDepartmantOrderByComment();
            return View(values);
        }
    }
}
