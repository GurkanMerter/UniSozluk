using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLayer.Abstract
{
    public interface IDepartmantService:IGenericService<Departmant>
    {
        List<Departmant> GetList(int id);

    }
}
