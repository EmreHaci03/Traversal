using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Abstract;
using Traversal.BusinessLayer.ValidationRules.AboutValidators;
using Traversal.DtoLayer.DTOS.AboutDtos;
using Traversal.DtoLayer.DTOS.DestinationDtos;
using Traversal.EntityLayer.Entities;

namespace Traversal.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class AboutController : Controller
    {
        private readonly IAboutService aboutService;
        private readonly IMapper _mapper;
        private readonly AboutValidator _validator;
        public AboutController(IAboutService aboutService, IMapper mapper, AboutValidator validator)
        {
            this.aboutService = aboutService;
            _mapper = mapper;
            _validator = validator;
        }
        [HttpGet]
        public IActionResult AboutList()
        {
            var values = aboutService.TGetAll();
            var mapper = _mapper.Map<List<ResultAboutDto>>(values);
            return View(mapper);
        }

        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto dto)
        {
            var result=_validator.Validate(dto);
            if (!result.IsValid)
            {
                foreach (var item in result.Errors) { 
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(dto);
            }

            var mapper = _mapper.Map<About>(dto);
            aboutService.TInsert(mapper);
            TempData["Success"] = "Hakkımızda içeriği başarıyla eklendi.";
            return RedirectToAction("AboutList");
        }

        [HttpPost]
        public IActionResult DeleteAbout(int id)
        {
            var About=aboutService.TGetById(id);
            if (About == null) { 
                TempData["NotFound"] = "Silinmek İstenen Veri Bulunamadı";
                return RedirectToAction("AboutList");
            }
            aboutService.TDelete(About);
            return RedirectToAction("AboutList");
        }


        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var about=aboutService.TGetById(id);
            if (about == null)
                return RedirectToAction("AboutList", "About");

            var mappedDto = _mapper.Map<UpdateAboutDto>(about);
            return View(mappedDto);
        }

        [HttpPost]
        public IActionResult UpdateAbout(UpdateAboutDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var mapper=_mapper.Map<About>(dto);
            aboutService.TUpdate(mapper);
            TempData["Update"] = "Güncelleme İşlemi Başarıyla Tamamlandı";
            return RedirectToAction("AboutList");  
        }


    }
}
