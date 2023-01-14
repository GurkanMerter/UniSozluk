using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLayer.Abstract
{
    public interface IUserService:IGenericService<User>
    {
        List<User> GetUserByID(int id);
        User GetUserWithUniversityByID(int id);
        List<User> GetUserListWithUniversityByID(int id);
        User GetUserWithDepartmantAndUniversity(int id);
        List<User> GetUsersWithDepartmantAndEntries();
    }
}
