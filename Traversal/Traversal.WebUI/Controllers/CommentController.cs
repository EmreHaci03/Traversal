using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Abstract;
using Traversal.DtoLayer.DTOS.CommentDtos;
using Traversal.EntityLayer.Entities;

namespace Traversal.WebUI.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;
        private readonly UserManager<AppUser> userManager;
        private readonly IMapper _mapper;

        public CommentController(ICommentService commentService, IMapper mapper, UserManager<AppUser> userManager)
        {
            this.commentService = commentService;
            _mapper = mapper;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult AddComment()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddComment(CreateCommentDto dto)
        {
            if (!User.Identity.IsAuthenticated)
            {
                TempData["Error"] = "Yorum yapabilmek için giriş yapmalısınız.";
                return RedirectToAction("DestinationDetail", "Destination", new { id = dto.DestinationId });
            }
            var user = await userManager.GetUserAsync(User);

            var comment = _mapper.Map<Comment>(dto);
            comment.AppUserId = user.Id;
            comment.NameSurname=user.Name+" " + user.Surname;
            comment.CommentDate = DateTime.Now;
            comment.CommentStatus = true;

            commentService.TInsert(comment);
            return RedirectToAction("DestinationDetail", "Destination", new { id = dto.DestinationId });
        }
    }
}
