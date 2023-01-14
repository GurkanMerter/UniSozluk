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
        public Entry GetEntryWithUniversityandUserAndDepartmantByID(int id)
        {
            
                using (var c = new Context())
                {
                    return c.Entries.Include(x => x.Departmant.University).Include(x=>x.Departmant).Include(x=>x.Users).Where(x => x.EntryID == id).FirstOrDefault();
                }
            
        }

        public Entry GetEntryWithUniversityByID(int id)
        {
            using (var c = new Context())
            {
                return c.Entries.Include(x=>x.Departmant.University).Where(x=>x.EntryID==id).FirstOrDefault();
            }
        }

        public Entry GetEntryWithUserByID(int id)
        {
            using (var c = new Context())
            {
                return c.Entries.Include(x=>x.Users).Where(x=>x.EntryID.Equals(id)).FirstOrDefault();
            }
        }

        public List<Entry> GetListWithDepartmantByUserID(int id)
        {
            using (var c = new Context())
            {
                return c.Entries.Include(x=>x.Departmant.University).Include(x=>x.Users).Where(x=>x.Users.UserID==id).ToList();
            }
        }

        public List<Entry> GetListWithDepartmantOrderByComment()
        {
            using (var c = new Context())
            {
                return c.Entries.Include(x=>x.Departmant.University).OrderBy(x=>x.Comments.Count()).ToList();
            }
        }
        
       

        public List<Entry> GetListWithDepartmantsByUniversity(int id)
        {
            using (var c = new Context())
            {
                return c.Entries.Include(x => x.Departmant).Where(x => x.Departmant.UniversityID.Equals(id)).ToList();
            }
        }

        public List<Entry> GetListWithUniversity()
        {
            
            using (var c = new Context())
            {
                return c.Entries.Include(x => x.Departmant.University).ToList();
               
            }
        }

        public List<Entry> GetListWithUniversityByUser(int id)
        {
            using (var c = new Context())
            {
                return c.Entries.Include(x => x.Departmant.University).Where(x=>x.UserID == id).ToList();

            }
        }

        public List<Entry> GetListWithUser(int id)
        {
            //throw new NotImplementedException();
            using (var c = new Context())
            {
                return c.Entries.Include(x => x.Users).Where(x=> x.Users.UserID == id).ToList();
               
            }
        }

        public List<Entry> GetListWithUser()
        {
            using (var c = new Context())
            {
                return c.Entries.Include(x => x.Users).ToList();

            }
        }
    }
}
