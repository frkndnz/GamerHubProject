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

        public IViewComponentResult Invoke(int gameId,int? skip=0,int? take=5)
        {
            var commentsDtos= _commentService.GetComments(gameId);
            var commentsViewModels=_mapper.Map<List<CommentViewModel>>(commentsDtos)
                .OrderByDescending(c=>c.CreatedAt);

            var totalCount= commentsViewModels.Count();

            var pagedComments=commentsViewModels.Skip(skip ?? 0)
                .Take(take ?? 5)
                .ToList();

            var componentViewModel = new CommentsComponentViewModel
            {
                Comments = pagedComments,
                TotalCount = totalCount,
                CurrentCount = (skip ?? 0) + (take ?? 5),
                GameId = gameId

            };
            
            return View(componentViewModel);
        }
    }
}
