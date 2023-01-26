using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccessLayer.Repositories
{
     public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T t)
        {
            using var c = new Context();
            c.Remove(t);
            c.SaveChanges();
        }

        public T GetByID(int id)
        {
            using var c = new Context();
            return c.Set<T>().Find(id); //id ye gelen değerleri göre bize verileri getiriyo olucak
        }

        public List<T> GetListAll()
        {
            using var c = new Context();
            return c.Set<T>().ToList();//sete bağlı olarak, kullanabileceği entity olmadığı için dışardan alıcak.
        }

        public void Insert(T t)
        {
            using var c = new Context();
            c.Entry(t).State = EntityState.Added;
            c.Add(t);
            c.SaveChanges();
        }

        //IGenericDal classında tanımlamış olduğum Expression yapısıyla birlikte Repository de interface i
        //implement ederek bu yapıyı burada kullanabiliriz;
        public List<T> GetListAll(Expression<Func<T, bool>> filter)
        {
            using var c = new Context();
            return c.Set<T>().Where(filter).ToList();//ile listeleme işlemini gerçekleştiricez.
        }

        public void Update(T t)
        {
            using var c = new Context();
            c.Entry(t).State = EntityState.Modified; //updatelerken oluşan hatanın önüne geçmek için kullandık
            c.Update(t);
            c.SaveChanges();
        }
    }
}
