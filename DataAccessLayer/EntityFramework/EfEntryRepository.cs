﻿using DataAccessLayer.Abstract;
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
        public List<Entry> GetListWithUniversity()
        {
            //throw new NotImplementedException(); -> implement interface ile
            using (var c = new Context())
            {
                return c.Entries.Include(x => x.Departmant.University).ToList();
               
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
    }
}
