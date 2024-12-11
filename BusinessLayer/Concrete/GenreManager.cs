using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class GenreManager : GenericService<Genre>
    {
        public GenreManager(IGenericRepository<Genre> genericDal) : base(genericDal)
        {
        }
    }
}
