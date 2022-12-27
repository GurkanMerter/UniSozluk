using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class//Entity gönderebilmek için "<T>" kullanmam gerek
    {//T bir classa ait bütün değerleri/nitelikleri kullanacak
        void Insert(T t);
        void Delete(T t);
        void Update(T t);

        List<T> GetListAll();
        T GetByID(int id);  //id ye göre çekebilmek için;

        List<T> GetListAll(Expression<Func<T, bool>> filter);//listeleme işlemi için;
                                                             //-> Bunun dışarıdan parametre alan hali ise istenilen herhangi bir niteliğe göre
                                                             // arama yapma işlemlerinde kullanılacak bir "LİNQ LAMDA işlemleri"

    }
}
