﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLayer.Abstract
{
    public interface IEntryService:IGenericService<Entry>
    {
        //deneme
        List<Entry> GetEntryListWithDepartmant(); //departmant göre listeleme işlemi
        List<Entry> GetEntryListByUser(int id);
        List<Entry> GetEntryByID(int id);
        List<Entry> GetListWithDepartmantsByUniversity(int id);
        List<Entry> GetListWithUser();
        List<Entry> Get5WithDepartmantOrderByComment();
        Entry GetEntryWithUniversityByID(int id);
        List<Entry> GetListWithDepartmantByUserID(int id);
        Entry GetEntryWithUserByID(int id);

        /*aaaaaaaaaaaaaaaaaaaaaaaaaaaaa*/
        Entry GetEntryWithUniversityandUserAndDepartmantByID(int id);
    }
}
