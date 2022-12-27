using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLayer.Abstract
{
    public interface IEntryService:IGenericService<Entry>
    {
        List<Entry> GetEntryListWithDepartmant(); //departmant göre listeleme işlemi
        List<Entry> GetEntryListByUser(int id);

    }
}
