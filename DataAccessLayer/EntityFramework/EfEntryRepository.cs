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
    public class EfEntryRepository : GenericRepository<Entry>, IEntryDal
    {
        public List<Entry> GetListWithDepartmantsByUniversity(int id)
        {
            using (var c = new Context())
            {
                return c.Entries.Include(x => x.Departmant).Where(x => x.Departmant.UniversityID.Equals(id)).ToList();
            }
        }

        public List<Entry> GetListWithUniversity()
        {
            //throw new NotImplementedException(); -> implement interface ile
            using (var c = new Context())
            {
                return c.Entries.Include(x => x.Departmant.University).ToList();
               
            }
        }

        public List<Entry> GetListWithUniversityByPerson(int id)
        {
            using (var c = new Context())
            {
                return c.Entries.Include(x => x.Departmant.University).Where(x=>x.PersonID == id).ToList();

            }
        }

        public List<Entry> GetListWithPerson(int id)
        {
            //throw new NotImplementedException();
            using (var c = new Context())
            {
                return c.Entries.Include(x => x.Persons).Where(x=> x.Persons.PersonID == id).ToList();
               
            }
        }
    }
}
