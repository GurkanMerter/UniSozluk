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
    public class EfUniversityRepository : GenericRepository<University>, IUniversityDal
    {
        //public University GetUniversityByUser(int id)
        //{
        //    using (var c = new Context())
        //    {
        //        return c.Universities.Where(x=>x.UniversityID.Equals(id)).FirstOrDefault();

        //    }
        //}
        //public List<University> GetUniversityByUser(User user)
        //{
        //    using (var c = new Context())
        //    {
        //       return c.Universities.Where(x=>x.UniversityID==user.Departmant.UniversityID).ToList();
        //    }
        //}
    }
}
