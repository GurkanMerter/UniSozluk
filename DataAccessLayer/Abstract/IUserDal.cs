using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Abstract
{
    public interface IUserDal : IGenericDal<User>
    {
        User GetUserWithUniversityByID(int id);
        List<User> GetUserListWithUniversityByID(int id);
        User GetUserWithDepartmantAndUniversity(int id);
        List<User> GetUsersWithDepartmantAndEntries();


    }
}
