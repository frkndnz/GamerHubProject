using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOLayer.DTOs.CommentDTOs;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ICommentService:IGenericService<Comment>
    {
        public List<CommentDTO> GetComments(int gameId);

        public void AddComment(AddCommentDTO commentDTO);
    }
}
