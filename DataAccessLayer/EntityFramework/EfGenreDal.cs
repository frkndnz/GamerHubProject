using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EfGenreDal : GenericRepository<Genre>
    {
        public EfGenreDal(Context context) : base(context)
        {
        }
    }
}
