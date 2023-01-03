using BussinesLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLayer.Concrete
{
    public class DepartmantManager : IDepartmantService
    {
        IDepartmantDal _departmantdal;

        public DepartmantManager(IDepartmantDal departmant)
        {
            _departmantdal = departmant;
        }

        public List<Departmant> GetList(int id)
        {
            throw new NotImplementedException();
        }

        public List<Departmant> GetList()
        {
            return _departmantdal.GetListAll();
        }

        public void TAdd(Departmant t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Departmant t)
        {
            throw new NotImplementedException();
        }

        public Departmant TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Departmant t)
        {
            throw new NotImplementedException();
        }

        public List<Departmant> GetListByUniversity(int id)
        {
            return _departmantdal.GetListAll(x => x.UniversityID == id);
        }
    }
}
