using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class GameManager : GenericService<Game>
    {
        public GameManager(IGenericDal<Game> genericDal) : base(genericDal)
        {
            
        }
    }
}