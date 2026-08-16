using AutoMapper;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Abstract;
using Traversal.BusinessLayer.ValidationRules.WhyChooseUsValidators;
using Traversal.DtoLayer.DTOS.WhyChooseUsDtos;
using Traversal.EntityLayer.Entities;

namespace Traversal.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class WhyChooseUsController : Controller
    {
        private readonly IWhyChooseUsService _whyChooseUsService;
        private readonly IMapper _mapper;
        private readonly WhyChooseUsValidator _validator;

        public WhyChooseUsController(IWhyChooseUsService whyChooseUsService, IMapper mapper, WhyChooseUsValidator validator)
        {
            _whyChooseUsService = whyChooseUsService;
            _mapper = mapper;
            _validator = validator;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var values = _whyChooseUsService.TGetAll();
            var mapper = _mapper.Map<List<ResultWhyChooseUsDto>>(values);
            return View(mapper);
        }
        [HttpGet]
        public IActionResult CreateWhyChooseUs()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateWhyChooseUs(CreateWhyChooseUsDto dto)
        {
            var result = _validator.Validate(dto);
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(dto);
            }

            var mapper=_mapper.Map<WhyChooseUs>(dto);
            _whyChooseUsService.TInsert(mapper);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult DeleteWhyChooseUs(int id)
        {
            var WhyChooseUs = _whyChooseUsService.TGetById(id);
            if (WhyChooseUs == null)
                return RedirectToAction("Index");

            _whyChooseUsService.TDelete(WhyChooseUs);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateWhyChooseUs(int id)
        {
            var WhyChooseUs = _whyChooseUsService.TGetById(id);
            if (WhyChooseUs == null)
                return RedirectToAction("Index");

            var mapper = _mapper.Map<UpdateWhyChooseUsDto>(WhyChooseUs);
            return View(mapper);
        }
        [HttpPost]
        public IActionResult UpdateWhyChooseUs(UpdateWhyChooseUsDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var mapper = _mapper.Map<WhyChooseUs>(dto);
            _whyChooseUsService.TUpdate(mapper);
            TempData["Success"] = "Neden Biz Alanı başarıyla Güncellendi.";
            return RedirectToAction("Index");
        }
    }
}
