using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLayer.Abstract
{
    public interface IPersonService:IGenericService<Person>
    {
        List<Person> GetPersonByID(int id);
        Person GetPersonWithUniversityByID(int id);
        List<Person> GetPersonListWithUniversityByID(int id);
        Person GetPersonWithDepartmantAndUniversity(int id);
        List<Person> GetPersonsWithDepartmantAndEntries();
    }
}
