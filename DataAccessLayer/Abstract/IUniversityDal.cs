using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Abstract
{
    public interface IUniversityDal : IGenericDal<University>
    {
        // List<University> GetListWithUniversity();

        //List<University> GetUniversityByUser(User user);
    }
}
