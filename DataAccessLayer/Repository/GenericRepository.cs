using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly Context _context;

        public GenericRepository(Context context)
        {
            _context = context;
        }

        public void Delete(T t)
        {
            throw new NotImplementedException();
        }

        public T? GetById(int id)
        {
            
            return _context.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            
            return _context.Set<T>().ToList();
        }

        public List<T> GetListByFilter(Expression<Func<T, bool>> t)
        {
            throw new NotImplementedException();
        }
        
        public void Insert(T t)
        {
            
            _context.Set<T>().Add(t);
            _context.SaveChanges();
            
        }
        public IEnumerable<T> GetAllWithInclude(Expression<Func<T, object>> includeProperty)
        {
            var _dbSet = _context.Set<T>();
            return _dbSet.Include(includeProperty).ToList();
        }
        public void Update(T t)
        {
            _context.Update(t);
            _context.SaveChanges();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}