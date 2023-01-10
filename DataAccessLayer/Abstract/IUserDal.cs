using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Abstract
{
    public interface IUserDal : IGenericDal<User>
    {
        User GetListWithUniversity(int id);
        User GetUserWithDepartmantAndUniversity(int id);

    }
}
