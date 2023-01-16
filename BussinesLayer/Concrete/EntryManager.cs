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

        public List<Entry> GetEntryListByPerson(int id)
        {
            return _entryDal.GetListWithPerson(id);
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

        public List<Entry> GetListWithUniversityByPerson(int id)
        {
            return _entryDal.GetListWithUniversityByPerson(id);
        }

        public List<Entry> GetListWithDepartmantsByUniversity(int id)
        {
            return _entryDal.GetListWithDepartmantsByUniversity(id);
        }
    }
}
