using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Abstract
{
    public interface IPersonDal : IGenericDal<Person>
    {
        Person GetListWithUniversity(int id);
        Person GetPersonWithDepartmantAndUniversity(int id);

    }
}
