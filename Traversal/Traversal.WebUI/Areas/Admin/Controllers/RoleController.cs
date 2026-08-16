using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Traversal.DtoLayer.DTOS.AppRoleDtos;
using Traversal.DtoLayer.DTOS.RoleDtos;
using Traversal.EntityLayer.Entities;
using Traversal.WebUI.Models.CreateRoleViewModel;
using Traversal.WebUI.Models.RoleAssignViewModel;
using Traversal.WebUI.Models.RoleCheckItemViewModel;

namespace Traversal.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> roleManager;
        private readonly UserManager<AppUser> userManager;
        private readonly IMapper _mapper;
        public RoleController(RoleManager<AppRole> roleManager, IMapper mapper, UserManager<AppUser> userManager)
        {
            this.roleManager = roleManager;
            _mapper = mapper;
            this.userManager = userManager;
        }
        [HttpGet]
        public  async Task<IActionResult> RoleList()
        {
            var values = await roleManager.Roles.ToListAsync();
            var maper = _mapper.Map<List<ResultAppRoleDto>>(values);
            return View(maper);
        }

        [HttpGet]
        public async Task<IActionResult> CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel viewModel)
        {
            AppRole appRole = new AppRole()
            {
                Name=viewModel.RoleName
            };

            var result=await roleManager.CreateAsync(appRole);

            if (result.Succeeded)
                return RedirectToAction("RoleList");

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var values = await roleManager.FindByIdAsync(id);
            if (values == null)
                return View();

            await roleManager.DeleteAsync(values);
            return RedirectToAction("RoleList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRole(string id)
        {
            var role = await roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
            if (role == null)
                return View();

            var mapper = _mapper.Map<UpdateAppRoleDto>(role);
            return View(mapper);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateAppRoleDto dto)
        {
            var role=await roleManager.Roles.FirstOrDefaultAsync(x=>x.Id==dto.Id);
            if (role == null)
                return NotFound("Güncellenmek İstenen Rol Bulunamadı!");

            role.Name=dto.RoleName;

            var result=await roleManager.UpdateAsync(role);

            if (result.Succeeded)
                return RedirectToAction("RoleList");

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(dto);
        }
        [HttpGet]
        public async Task<IActionResult> AssignRole(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound("Kullanıcı Bulunamadı");

            var allRoles = await roleManager.Roles.ToListAsync();
            var userRoles = await userManager.GetRolesAsync(user);

            var model = new RoleAssignViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                roleChecks = allRoles.Select(x => new RoleCheckViewModel
                {
                    RoleId = x.Id,
                    RoleName = x.Name,
                    IsSelected = userRoles.Contains(x.Name)
                }).ToList()

            };

            return View(model); 

        }
        [HttpPost]  
        public async Task<IActionResult> AssignRole(RoleAssignViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.UserId);
            if(user==null)
                return NotFound("Kullanıcı Bulunamadı");

            var currentRoles = await userManager.GetRolesAsync(user);

            var selectedRoles = model.roleChecks
                .Where(x => x.IsSelected)
                 .Select(x => x.RoleName)
                 .ToList();

            var rolesToAdd = selectedRoles.Except(currentRoles).ToList(); 
            var rolesToRemove = currentRoles.Except(selectedRoles).ToList(); //Kullanıcının ŞU AN SAHİP OLDUĞU roller içinde olup, formda SEÇİLMEYEN rolleri bul.


            if (rolesToAdd.Any())
                await userManager.AddToRolesAsync(user, rolesToAdd);

            if (rolesToRemove.Any())
                await userManager.RemoveFromRolesAsync(user, rolesToRemove);

            return RedirectToAction("RoleList");
        }
    }
}
