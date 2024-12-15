using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class GenreService : GenericService<Genre>,IGenreService
    {
        public GenreService(IGenericRepository<Genre> genericDal) : base(genericDal)
        {
        }
    }
}
