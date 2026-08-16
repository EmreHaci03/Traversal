using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Traversal.BusinessLayer.Abstract;
using Traversal.EntityLayer.Entities;

namespace Traversal.WebUI.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IFavoriteService favoriteService;
        private readonly IReservationService reservationService;
        private readonly ICommentService commentService;
        public DashboardController(UserManager<AppUser> userManager, IFavoriteService favoriteService, IReservationService reservationService, ICommentService commentService)
        {
            this.userManager = userManager;
            this.favoriteService = favoriteService;
            this.reservationService = reservationService;
            this.commentService = commentService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);
            ViewBag.UserCommentCount = commentService.TCommentCountDestinationUser(user.Id) ;
            ViewBag.ReservationCount = reservationService.TReservationByUser(user.Id);
            ViewBag.FavoritePlaces = favoriteService.TFavoritePlaces(user.Id);
            return View(user);
        }
    }
}
