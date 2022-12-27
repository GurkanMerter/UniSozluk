using BussinesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace UniSozluk.ViewComponents.UserNickName
{
    public class GetUserNickName:ViewComponent
    {
        UserManager um = new UserManager(new EfUserRepository());

        public IViewComponentResult Invoke(int id)
        {
            var values = um.GetUserByID(id); //id değerini buna göre alıyorum.
            return View(values);
        }

    }
}
