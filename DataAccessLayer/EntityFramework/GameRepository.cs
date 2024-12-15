using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class GameRepository : GenericRepository<Game>,IGameRepo
    {
        private readonly Context _context;
        public GameRepository(Context context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Game> GetAllWithGenres()
        {
            var dbset=_context.Set<Game>();
            return dbset.Include(g=>g.Genres).ToList();
        }
    }
}