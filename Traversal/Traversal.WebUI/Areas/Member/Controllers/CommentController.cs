using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Traversal.BusinessLayer.Abstract;
using Traversal.DtoLayer.DTOS.CommentDtos;
using Traversal.EntityLayer.Entities;

namespace Traversal.WebUI.Areas.Member.Controllers
{
    [Area("Member")]
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;
        private readonly UserManager<AppUser> userManager;
        private readonly IMapper _mapper;
        public CommentController(ICommentService commentService, UserManager<AppUser> userManager, IMapper mapper)
        {
            this.commentService = commentService;
            this.userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> CommentListWithDestination()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");


            var commentList = commentService.TCommentListWithDestinationUser( user.Id);
            var mapper = _mapper.Map<List<ResultCommentDto>>(commentList);
            return View(mapper);
        }
    }
}
