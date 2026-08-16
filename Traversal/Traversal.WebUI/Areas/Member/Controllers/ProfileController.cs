using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Abstract;
using Traversal.EntityLayer.Entities;
using Traversal.WebUI.Models.ProfileViewModel;

namespace Traversal.WebUI.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IFavoriteService favoriteService;
        private readonly IReservationService reservationService;
        private readonly ICommentService commentService;

        public ProfileController(UserManager<AppUser> userManager, IFavoriteService favoriteService, IReservationService reservationService, ICommentService commentService)
        {
            this.userManager = userManager;
            this.favoriteService = favoriteService;
            this.reservationService = reservationService;
            this.commentService = commentService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user=await userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");

            var viewModel = new ProfileViewModel
            {
                Name = user.Name,
                Surname = user.Surname,
                UserName = user.UserName,
                ImageUrl = user.ImageUrl,
                Email = user.Email
            };
            ViewBag.CommentCount = commentService.TCommentCountDestinationUser(user.Id);
            ViewBag.ActiveReservationCount = reservationService.TActiveReservationCount(user.Id);
            ViewBag.FavoritePlacesCount = favoriteService.TFavoritePlaces(user.Id);

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(ProfileViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var user = await userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");

            if (viewModel.Image != null)
            {
                var resource = Directory.GetCurrentDirectory(); //Uygulamanın çalıştığı klasörün tam yolunu alır.
                var extension = Path.GetExtension(viewModel.Image.FileName);//Kullanıcının yüklediği dosyanın adından sadece uzantıyı alır Örn :Jpg
                var imagename=Guid.NewGuid()+ extension;//Guid Oluşturur.
                var saveLocation = resource + "/wwwroot/userimages/" + imagename;//
                using (var stream = new FileStream(saveLocation, FileMode.Create))
                {
                    await viewModel.Image.CopyToAsync(stream);
                };
                user.ImageUrl = imagename;
            }

            user.Name = viewModel.Name;
            user.Surname = viewModel.Surname;
            user.PasswordHash = userManager.PasswordHasher.HashPassword(user, viewModel.Password);

            var result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                TempData["Success"] = "Profile Bilgileri Başarıyla Güncellendi";
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            ViewBag.Image = user.ImageUrl;

            return View(viewModel);

        }
    }
}
