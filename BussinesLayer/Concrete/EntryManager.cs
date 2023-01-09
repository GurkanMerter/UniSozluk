using BussinesLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
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
    }
}
