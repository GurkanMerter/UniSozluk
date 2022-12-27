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
            throw new NotImplementedException();
        }

        public void TDelete(Entry t)
        {
            throw new NotImplementedException();
        }

        public Entry TGetById(int id)
        {
            return _entryDal.GetByID(id);
        }

        public void TUpdate(Entry t)
        {
            throw new NotImplementedException();
        }
    }
}
