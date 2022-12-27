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
        public List<User> GetListWithUniversity()
        {
            //throw new NotImplementedException(); -> implement interface ile
            using (var c = new Context())
            {
                //return c.Users.Include(x => x.Departmant.DepartmantID).ToList();
                return null;
            }
        }
    }
}
