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
        public IActionResult LoadComments(int gameId)
        {
            return ViewComponent("CommentListComponent", new { gameId });
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult AddComment(AddCommentViewModel model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return StatusCode(401);
            }

            if (ModelState.IsValid)
            {
                var addCommentDto = _mapper.Map<AddCommentDTO>(model);

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


                if (userId == null)
                {
                    return Unauthorized();
                }

                addCommentDto.AppUserId = int.Parse(userId);
                _commentService.AddComment(addCommentDto);

                return Ok();

            }
            else
            {

                return BadRequest("Yorum geçerli değil!");
            }


        }
    }
}
