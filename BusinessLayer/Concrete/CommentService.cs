using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DTOLayer.DTOs.CommentDTOs;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CommentService : GenericService<Comment>,ICommentService
    {
        private readonly ICommentRepo _commentRepository;
        private readonly IMapper _mapper;
        public CommentService(ICommentRepo commentRepository, IMapper mapper) : base(commentRepository)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public void AddComment(AddCommentDTO commentDTO)
        {
            var commentEntity= _mapper.Map<Comment>(commentDTO);
            _commentRepository.Insert(commentEntity);
        }

        public List<CommentDTO> GetComments(int gameId)
        {
            var comments = _commentRepository.GetCommentsWithUsers().Where(c=>c.GameId == gameId).ToList();
            var commentsDTO=_mapper.Map<List<CommentDTO>>(comments);
            return commentsDTO;
        }


    }
}
