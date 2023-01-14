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
    public class EfDepartmantRepository : GenericRepository<Departmant>, IDepartmantDal
    {
        public List<Departmant> GetListByUniversityID(int id)
        {
            using(var c = new Context())
            {
                return c.Departmants.Where(x=>x.UniversityID == id).ToList();
            }
        }
    }
}
