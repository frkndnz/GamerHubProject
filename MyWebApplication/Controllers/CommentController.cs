using System.Security.Claims;
using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.CommentDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebApplication.ViewModel.Comment;

namespace MyWebApplication.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentController(IMapper mapper, ICommentService commentService)
        {
            _mapper = mapper;
            _commentService = commentService;
        }

        [HttpGet]
        public IActionResult GetCommentsComponent(int gameId, int skip=0, int take=5)
        {
            return ViewComponent("CommentListComponent", new { gameId, skip, take });
        }

        [HttpGet]
        public IActionResult LoadMore(int gameId, int skip, int take)
        {
            var commentsDtos = _commentService.GetComments(gameId);
            var commentsViewModels = _mapper.Map<List<CommentViewModel>>(commentsDtos)
                .OrderByDescending(c=>c.CreatedAt)
                .Skip(skip)
                .Take(take)
                .ToList();

            return PartialView("~/Views/Shared/CommentPartials/_CommentListPartial.cshtml", commentsViewModels);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult AddComment([FromForm]AddCommentViewModel model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized(new { message = "Bu işlem için giriş yapmalısınız." });
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage);
                return BadRequest(new { message = "Geçersiz form verisi.", errors });
            }

            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized(new { message = "Kullanıcı bilgisi bulunamadı." });
                }

                var addCommentDto = _mapper.Map<AddCommentDTO>(model);
                addCommentDto.AppUserId = int.Parse(userId);

                var commentDto = _commentService.AddComment(addCommentDto);
                var commentViewModel = _mapper.Map<CommentViewModel>(commentDto);

                return PartialView("~/Views/Shared/CommentPartials/_CommentListPartial.cshtml",
                    new List<CommentViewModel> { commentViewModel });
            }
            catch (Exception ex)
            {
                

                return StatusCode(500, new
                {
                    success = false,
                    message = "Yorum eklenirken bir hata oluştu."
                });
            }


        }
    }
}
