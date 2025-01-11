using AutoMapper;
using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using MyWebApplication.ViewModel.Comment;

namespace MyWebApplication.ViewComponents
{
    public class CommentListComponent:ViewComponent
    {
        // oyunıd sine sahip tüm yorumlar gelicek
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentListComponent(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke(int gameId)
        {
            var commentsDtos= _commentService.GetComments(gameId);
            var commentsViewModels=_mapper.Map<List<CommentViewModel>>(commentsDtos);

            return View(commentsViewModels);
        }
    }
}
