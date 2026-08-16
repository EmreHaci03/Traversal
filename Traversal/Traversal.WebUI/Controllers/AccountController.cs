using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Traversal.EntityLayer.Entities;
using Traversal.WebUI.Models.LoginViewModel;
using Traversal.WebUI.Models.RegisterViewModel;

namespace Traversal.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            AppUser appUser = new AppUser()
            {
                Name = viewModel.Name,
                Surname=viewModel.Surname,
                UserName=viewModel.Username,
                Email=viewModel.Mail,
                Gender=viewModel.Gender,
            };
            if (viewModel.Password == viewModel.ConfirmPassword)
            {
                var result = await userManager.CreateAsync(appUser, viewModel.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(viewModel);

        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var user = await userManager.FindByNameAsync(viewModel.Username);

            if (user == null)
            {
                user = await userManager.FindByEmailAsync(viewModel.Username);
            }

            if (user == null)
            {
                ModelState.AddModelError("", "Kullanıcı bulunamadı.");
                return View(viewModel);
            }

            var result = await signInManager.PasswordSignInAsync(user, viewModel.Password,false, lockoutOnFailure: true);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Profile", new { area = "Member" });
            }
            else if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Hesabınız çok fazla hatalı denemeden dolayı kilitlendi. Lütfen daha sonra tekrar deneyin.");
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı.");
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
