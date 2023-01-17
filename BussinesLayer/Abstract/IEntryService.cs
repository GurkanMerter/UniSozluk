using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLayer.Abstract
{
    public interface IEntryService:IGenericService<Entry>
    {
        List<Entry> GetEntryListWithDepartmant(); //departmant göre listeleme işlemi
        List<Entry> GetEntryListByPerson(int id);
        List<Entry> GetEntryByID(int id);
        List<Entry> GetListWithDepartmantsByUniversity(int id);
        List<Entry> GetListWithPerson();
        List<Entry> Get5WithDepartmantOrderByComment();
        Entry GetEntryWithUniversityByID(int id);
        List<Entry> GetListWithDepartmantByPersonID(int id);
        Entry GetEntryWithPersonByID(int id);

        /*aaaaaaaaaaaaaaaaaaaaaaaaaaaaa*/
        Entry GetEntryWithUniversityandPersonAndDepartmantByID(int id);
    }
}
