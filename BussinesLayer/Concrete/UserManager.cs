using BussinesLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLayer.Concrete
{
    public class PersonManager : IPersonService
    {
        IPersonDal _PersonDal;

        public PersonManager(IPersonDal PersonDal)
        {
            _PersonDal = PersonDal;
        }

        public List<Person> GetList()
        {
            return _PersonDal.GetListAll(); //admin panelinde bütün yazarları listelemek için
        }

        public Person GetPersonWithUniversityByID(int id)
        {
            return _PersonDal.GetPersonWithUniversityByID(id);
        }

        public List<Person> GetPersonByID(int id)
        {
            return _PersonDal.GetListAll(x=>x.PersonID==id);
        }

        public List<Person> GetPersonsWithDepartmantAndEntries()
        {
            return _PersonDal.GetPersonsWithDepartmantAndEntries();
        }

        public Person GetPersonWithDepartmantAndUniversity(int id)
        {
            return _PersonDal.GetPersonWithDepartmantAndUniversity(id);
        }

        public void TAdd(Person t)
        {
            _PersonDal.Insert(t);
        }

        public void TDelete(Person t)
        {
           _PersonDal.Delete(t);
        }

        public Person TGetById(int id)
        {
            return _PersonDal.GetByID(id);
        }

        public void TUpdate(Person t)
        {
            _PersonDal.Update(t);
        }

        public List<Person> GetPersonListWithUniversityByID(int id)
        {
            return _PersonDal.GetPersonListWithUniversityByID(id);
        }
    }
}
