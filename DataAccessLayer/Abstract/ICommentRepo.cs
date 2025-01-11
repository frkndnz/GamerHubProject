using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface ICommentRepo:IGenericRepository<Comment>
    {
        public List<Comment> GetCommentsWithUsers();
    }
}
