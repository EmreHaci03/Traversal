using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Traversal.BusinessLayer.Abstract;
using Traversal.DtoLayer.DTOS.FavoriteDtos;
using Traversal.DtoLayer.DTOS.ReservationDtos;
using Traversal.EntityLayer.Entities;

namespace Traversal.WebUI.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize]
    public class FavoriteController : Controller
    {
        private readonly IFavoriteService favoriteService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> userManager;

        public FavoriteController(IFavoriteService favoriteService, UserManager<AppUser> userManager, IMapper mapper)
        {
            this.favoriteService = favoriteService;
            this.userManager = userManager;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");
            var values = favoriteService.TGetFavoriteListByUser(user.Id);
            if (values == null)
                return RedirectToAction("MyCurrentReservation", "Reservation", new { area = "Member" });

            var mapper = _mapper.Map<List<ResultFavoriteDto>>(values);
            return View(mapper);
        }

        [HttpPost]
        public async Task<IActionResult> AddFavorite(int id)
        {

            var user = await userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");

            var hasAlreadyFavorite=favoriteService.TAnyFavorite(x=>x.AppUserId== user.Id && x.DestinationId==id);
            if (hasAlreadyFavorite)
            {
                TempData["Info"] = "Bu tur zaten favorilerinizde.";
                return RedirectToAction("Index","Destination", new { area = "Member" });
            }


            var favorite = new Favorite
            {
                DestinationId = id,
                AppUserId = user.Id,
                AddedDate = DateTime.Now,
            };
            favoriteService.TInsert(favorite);
            TempData["Success"] = "Favorilere eklendi.";
            return RedirectToAction("Index", "Destination", new { area = "Member" });
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFavorite(int id)
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");

            var favorite = favoriteService.TGetById(id);
            if (favorite == null)
            {
                TempData["NotFound"] = "Seçtiğiniz Favori Tur Bulunamadı";
                return RedirectToAction("Index");
            }

            favoriteService.TDelete(favorite);
            return RedirectToAction("Index");

        }
    }
}
