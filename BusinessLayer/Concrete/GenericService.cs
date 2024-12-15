using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;


namespace BusinessLayer.Concrete
{
    public class GenericService<T> : IGenericService<T> where T:class
    {
        private readonly IGenericRepository<T> _genericRepository;

        public GenericService(IGenericRepository<T> genericDal)
        {
            _genericRepository = genericDal;
        }

        

        public T? GetById(int id)
        {
            return _genericRepository.GetById(id);
            
        }

        public void TAdd(T t)
        {
            _genericRepository.Insert(t);
        }

        public void TDelete(T t)
        {
            _genericRepository.Delete(t);
        }

        public  List<T> TGetList()
        {
            return _genericRepository.GetList();
        }

        public List<T> TGetListByFilter(Expression<Func<T, bool>> filter)
        {
            return _genericRepository.GetListByFilter(filter);
        }

        public void TUpdate(T t)
        {
            _genericRepository.Update(t);
        }
    }
}