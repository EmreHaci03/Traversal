using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Abstract;
using Traversal.BusinessLayer.ValidationRules.FeatureMainValidators;
using Traversal.DtoLayer.DTOS.FeatureMainDtos;
using Traversal.EntityLayer.Entities;

namespace Traversal.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class FeatureMainController : Controller
    {
        private readonly IFeatureMainService featureMainService;
        private readonly FeatureMainValidator _validator;
        private readonly IMapper _mapper;
        public FeatureMainController(IFeatureMainService featureMainService, IMapper mapper, FeatureMainValidator validator)
        {
            this.featureMainService = featureMainService;
            _mapper = mapper;
            _validator = validator;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var values = featureMainService.TGetAll();
            var mapper = _mapper.Map<List<ResultFeatureMainDto>>(values);
            return View(mapper);
        }
        [HttpGet]
        public IActionResult CreateFeatureMain()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateFeatureMain(CreateFeatureMainDto dto)
        {
            var result = _validator.Validate(dto);
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                return View(dto);
            }
            var mapper=_mapper.Map<FeatureMain>(dto);  
            featureMainService.TInsert(mapper);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult DeleteFeatureMain(int id)
        {
            var FeatureMain = featureMainService.TGetById(id);
            if (FeatureMain == null)
                return View();
            featureMainService.TDelete(FeatureMain);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateFeatureMain(int id)
        {
            var FeatureMain = featureMainService.TGetById(id);
            if (FeatureMain == null)
                return View();
            var mapper = _mapper.Map<UpdateFeatureMainDto>(FeatureMain);
            return View(mapper);
        }
        [HttpPost]
        public IActionResult UpdateFeatureMain(UpdateFeatureMainDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var mapper=_mapper.Map<FeatureMain>(dto);
            featureMainService.TUpdate(mapper);
            return RedirectToAction("Index");
        }
    }
}
