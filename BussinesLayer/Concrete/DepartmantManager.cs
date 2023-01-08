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
            return _departmantdal.GetListAll();
        }

        public List<Departmant> GetList()
        {
            return _departmantdal.GetListAll();
        }

        public void TAdd(Departmant t)
        {
             _departmantdal.Insert(t);
        }

        public void TDelete(Departmant t)
        {
            _departmantdal.Delete(t);
        }

        public Departmant TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Departmant t)
        {
            _departmantdal.Update(t);
        }

        public List<Departmant> GetListByUniversity(int id)
        {
            return _departmantdal.GetListAll(x => x.UniversityID == id);
        }
    }
}
