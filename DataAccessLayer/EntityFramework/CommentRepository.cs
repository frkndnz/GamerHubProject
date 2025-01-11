using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class CommentRepository : GenericRepository<Comment>,ICommentRepo
    {
        private readonly Context _context;
        public CommentRepository(Context context) : base(context)
        {
            _context = context;
        }

        public List<Comment> GetCommentsWithUsers()
        {
            var dbSet= _context.Set<Comment>();
            return dbSet.Include(c=>c.AppUser).ToList();
        }
    }
}
