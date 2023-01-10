using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.EntityFramework
{
    public class EfUserRepository : GenericRepository<User>, IUserDal
    {
        public User GetListWithUniversity(int id)
        {
            using (var c = new Context())
            {
                return c.Users.Include(x => x.Departmant.University).Where(x=>x.UserID==id).FirstOrDefault();
            }
        }

        public User GetUserWithDepartmantAndUniversity(int id)
        {
            using (var c = new Context())
            {
                return c.Users.Include(x => x.Departmant).Include(x=>x.Departmant.University).Where(x => x.UserID == id).FirstOrDefault();
            }
        }
    }
}
