using BussinesLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLayer.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<User> GetList()
        {
            return _userDal.GetListAll(); //admin panelinde bütün yazarları listelemek için
        }

        public User GetListWithUniversity(int id)
        {
            return _userDal.GetListWithUniversity(id);
        }

        public List<User> GetUserByID(int id)
        {
            return _userDal.GetListAll(x=>x.UserID==id);
        }

        public User GetUserWithDepartmantAndUniversity(int id)
        {
            return _userDal.GetUserWithDepartmantAndUniversity(id);
        }

        public void TAdd(User t)
        {
            _userDal.Insert(t);
        }

        public void TDelete(User t)
        {
            throw new NotImplementedException();
        }

        public User TGetById(int id)
        {
            return _userDal.GetByID(id);
        }

        public void TUpdate(User t)
        {
            throw new NotImplementedException();
        }

    }
}
