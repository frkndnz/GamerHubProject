using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.CommentDTOs
{
    public class AddCommentDTO
    {
        public string Content { get; set; }
        public int GameId;
        public int AppUserId;
    }
}
