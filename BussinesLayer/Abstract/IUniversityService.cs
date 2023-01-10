using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLayer.Abstract
{
    public interface IUniversityService:IGenericService<University>
    {
        List<University> GetList(int id);
        //List<University> GetUniversityByUser(User user);
    }
}
