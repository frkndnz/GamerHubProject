using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericRepository<T>
    {
        void Insert(T t);
        void Delete(T t);
        void Update(T t);

        List<T> GetList();

        T? GetById(int id);

        List<T> GetListByFilter(Expression<Func<T,bool>> t);
        IEnumerable<T> GetAllWithInclude(Expression<Func<T, object>> includeProperty);
    }
}