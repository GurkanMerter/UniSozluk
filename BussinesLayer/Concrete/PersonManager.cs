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
        IPersonDal _personDal;

        public PersonManager(IPersonDal personDal)
        {
            _personDal = personDal;
        }

        public List<Person> GetList()
        {
            return _personDal.GetListAll(); //admin panelinde bütün yazarları listelemek için
        }

        public Person GetListWithUniversity(int id)
        {
            return _personDal.GetListWithUniversity(id);
        }   

        public List<Person> GetPersonByID(int id)
        {
            return _personDal.GetListAll(x=>x.PersonID ==id);
        }

        public Person GetPersonWithDepartmantAndUniversity(int id)
        {
            return _personDal.GetPersonWithDepartmantAndUniversity(id);
        }

        public void TAdd(Person t)
        {
            _personDal.Insert(t);
        }

        public void TDelete(Person t)
        {
            throw new NotImplementedException();
        }

        public Person TGetById(int id)
        {
            return _personDal.GetByID(id);
        }

        public void TUpdate(Person t)
        {
            throw new NotImplementedException();
        }

    }
}
