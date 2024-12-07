using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T t)
        {
            throw new NotImplementedException();
        }

        public T? GetById(int id)
        {
            using var c =new Context();
            return c.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            using var c =new Context();
            return c.Set<T>().ToList();
        }

        public List<T> GetListByFilter(Expression<Func<T, bool>> t)
        {
            throw new NotImplementedException();
        }

        public void Insert(T t)
        {
            using var c =new Context();
            c.Add(t);
            
        }

        public void Update(T t)
        {
            throw new NotImplementedException();
        }
    }
}