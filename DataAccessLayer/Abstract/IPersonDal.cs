using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Abstract
{
    public interface IPersonDal : IGenericDal<Person>
    {
        Person GetPersonWithUniversityByID(int id);
        List<Person> GetPersonListWithUniversityByID(int id);
        Person GetPersonWithDepartmantAndUniversity(int id);
        List<Person> GetPersonsWithDepartmantAndEntries();


    }
}
