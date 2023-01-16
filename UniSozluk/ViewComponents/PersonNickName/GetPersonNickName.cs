using BussinesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace UniSozluk.ViewComponents.PersonNickName
{
    public class GetPersonNickName:ViewComponent
    {
        PersonManager um = new PersonManager(new EfPersonRepository());

        public IViewComponentResult Invoke(int id)
        {
            var values = um.GetPersonByID(id); //id değerini buna göre alıyorum.
            return View(values);
        }

    }
}
