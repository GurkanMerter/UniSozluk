using BussinesLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLayer.Concrete
{
    public class UniversityManager : IUniversityService
    {
        IUniversityDal _universitydal;

        public UniversityManager(IUniversityDal universitydal)
        {
            _universitydal = universitydal;
        }

        public List<University> GetList()
        {
            return _universitydal.GetListAll();
        }

        public List<University> GetList(int id)
        {
            return _universitydal.GetListAll(x=>x.UniversityID == id);
        }

        //public List<University> GetUniversityByUser(User user)
        //{
        //    return  _universitydal.GetUniversityByUser(user);
        //}

        public void TAdd(University t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(University t)
        {
            throw new NotImplementedException();
        }

        public University TGetById(int id)
        {
            return _universitydal.GetByID(id);
        }

        public void TUpdate(University t)
        {
            throw new NotImplementedException();
        }
    }
}
