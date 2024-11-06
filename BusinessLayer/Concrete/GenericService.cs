using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;


namespace BusinessLayer.Concrete
{
    public class GenericService<T> : IGenericService<T> where T:class
    {
        private readonly IGenericDal<T> _genericDal;

        public GenericService(IGenericDal<T> genericDal)
        {
            _genericDal = genericDal;
        }

        public T? GetById(int id)
        {
            return _genericDal.GetById(id);
            
        }

        public void TAdd(T t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(T t)
        {
            throw new NotImplementedException();
        }

        public List<T> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(T t)
        {
            throw new NotImplementedException();
        }
    }
}