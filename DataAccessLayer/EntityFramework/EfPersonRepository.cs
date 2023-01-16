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
    public class EfPersonRepository : GenericRepository<Person>, IPersonDal
    {
        public Person GetPersonWithUniversityByID(int id)
        {
            using (var c = new Context())
            {
                return c.Persons.Include(x => x.Departmant.University).Where(x=>x.PersonID==id).FirstOrDefault();
            }
        }

        public List<Person> GetPersonsWithDepartmantAndEntries()
        {
            using (var c = new Context())
            {
                return c.Persons.Include(x => x.Departmant.University).Include(x=>x.Entrys).ToList();
            }
        }

        public Person GetPersonWithDepartmantAndUniversity(int id)
        {
            using (var c = new Context())
            {
                return c.Persons.Include(x => x.Departmant).Include(x=>x.Departmant.University).Where(x => x.PersonID == id).FirstOrDefault();
            }
        }

        List<Person> IPersonDal.GetPersonListWithUniversityByID(int id)
        {
            using (var c = new Context())
            {
                return c.Persons.Include(x => x.Departmant.University).Where(x => x.PersonID == id).ToList();
            }
        }
    }
}
