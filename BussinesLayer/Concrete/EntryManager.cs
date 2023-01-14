using BussinesLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinesLayer.Concrete
{
    public class EntryManager : IEntryService
    {
        IEntryDal _entryDal;

        public EntryManager(IEntryDal entryDal)
        {
            _entryDal = entryDal;
        }

        public List<Entry> GetEntryByID(int id)
        {
            return  _entryDal.GetListAll(x=>x.EntryID == id);
        }

        public List<Entry> GetEntryListByUser(int id)
        {
            return _entryDal.GetListWithUser(id);
        }

        public List<Entry> GetEntryListWithDepartmant()
        {
            return _entryDal.GetListWithUniversity(); //metodu öyle çağırmış olduk
        }

        public List<Entry> GetList()
        {
            return _entryDal.GetListAll();
        }

        public void TAdd(Entry t)
        {
            _entryDal.Insert(t);
        }

        public void TDelete(Entry t)
        {
            _entryDal.Delete(t);
        }

        public Entry TGetById(int id)
        {
            return _entryDal.GetByID(id);
        }

        public void TUpdate(Entry t)
        {
            _entryDal.Update(t);
        }

        public List<Entry> GetListWithUniversityByUser(int id)
        {
            return _entryDal.GetListWithUniversityByUser(id);
        }

        public List<Entry> GetListWithDepartmantsByUniversity(int id)
        {
            return _entryDal.GetListWithDepartmantsByUniversity(id);
        }

        public List<Entry> GetListWithUser()
        {
            return _entryDal.GetListWithUser();
        }

        public List<Entry> Get5WithDepartmantOrderByComment()
        {
            return _entryDal.GetListWithDepartmantOrderByComment().Take(5).ToList();
        }

        public Entry GetEntryWithUniversityByID(int id)
        {
            return _entryDal.GetEntryWithUniversityByID(id);
        }

        public List<Entry> GetListWithDepartmantByUserID(int id)
        {
            return _entryDal.GetListWithDepartmantByUserID(id);
        }

        public Entry GetEntryWithUserByID(int id)
        {
            return _entryDal.GetEntryWithUserByID(id);
        }
    }
}
