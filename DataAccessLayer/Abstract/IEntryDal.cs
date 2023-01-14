using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Abstract
{
    public interface IEntryDal : IGenericDal<Entry>
    {
        List<Entry> GetListWithUniversity();
        List<Entry> GetListWithUser(int id);
        List<Entry> GetListWithUser();
        List<Entry> GetListWithUniversityByUser(int id);
        List<Entry> GetListWithDepartmantsByUniversity(int id);
        List<Entry> GetListWithDepartmantOrderByComment();
        Entry GetEntryWithUniversityByID(int id);
        List<Entry> GetListWithDepartmantByUserID(int id);
        Entry GetEntryWithUserByID(int id);
        
        //List<Entry> GetListWithDepartmantOrderByLike();
    }
}
