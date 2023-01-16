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
        List<Entry> GetListWithPerson(int id);
        List<Entry> GetListWithPerson();
        List<Entry> GetListWithUniversityByPerson(int id);
        List<Entry> GetListWithDepartmantsByUniversity(int id);
        List<Entry> GetListWithDepartmantOrderByComment();
        Entry GetEntryWithUniversityByID(int id);
        List<Entry> GetListWithDepartmantByPersonID(int id);
        Entry GetEntryWithPersonByID(int id);

        //List<Entry> GetListWithDepartmantOrderByLike();

        /*aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa*/
        Entry GetEntryWithUniversityandPersonAndDepartmantByID(int id);


    }
}
