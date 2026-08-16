using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Abstract;
using Traversal.BusinessLayer.ValidationRules.FeatureGridValidators;
using Traversal.DtoLayer.DTOS.FeatureGridDtos;
using Traversal.EntityLayer.Entities;

namespace Traversal.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class FeatureGridController : Controller
    {
        private readonly IFeatureGridService featureGridService;
        private readonly FeatureGridValidator _validator;
        private readonly IMapper _mapper;

        public FeatureGridController(IFeatureGridService featureGridService, IMapper mapper, FeatureGridValidator validator)
        {
            this.featureGridService = featureGridService;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var values = featureGridService.TGetAll();
            var mapper = _mapper.Map<List<ResultFeatureGridDto>>(values);
            return View(mapper);
        }

        [HttpGet]
        public IActionResult CreateFeatureGrid()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateFeatureGrid(CreateFeatureGridDto dto)
        {
            var result = _validator.Validate(dto);
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                return View(dto);
            }

            var featureGrid = _mapper.Map<FeatureGrid>(dto);
            featureGridService.TInsert(featureGrid);

            TempData["Success"] = "Kayıt başarıyla eklendi.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteFeatureGrid(int id)
        {
            var featureGrid = featureGridService.TGetById(id);
            if (featureGrid == null)
            {
                TempData["Error"] = "Silinmek istenen kayıt bulunamadı.";
                return RedirectToAction("Index");
            }

            featureGridService.TDelete(featureGrid);
            TempData["Success"] = "Kayıt başarıyla silindi.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateFeatureGrid(int id)
        {
            var featureGrid = featureGridService.TGetById(id);
            if (featureGrid == null)
                return RedirectToAction("Index");

            var mapped = _mapper.Map<UpdateFeatureGridDto>(featureGrid);
            return View(mapped);
        }

        [HttpPost]
        public IActionResult UpdateFeatureGrid(UpdateFeatureGridDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var featureGrid = _mapper.Map<FeatureGrid>(dto);
            featureGridService.TUpdate(featureGrid);

            TempData["Success"] = "Kayıt başarıyla güncellendi.";
            return RedirectToAction("Index");
        }
    }
}