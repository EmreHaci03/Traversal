using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Abstract;
using Traversal.BusinessLayer.ValidationRules.InfoCardValidators;
using Traversal.DtoLayer.DTOS.InfoCardDtos;
using Traversal.EntityLayer.Entities;

namespace Traversal.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InfoCardController : Controller
    {
        private readonly IInfoCardService infoCardService;
        private readonly IMapper _mapper;
        private readonly InfoCardValidator _validator;
        private readonly UpdateInfoCardValidator _updateValidator;
        public InfoCardController(IInfoCardService ınfoCardService, IMapper mapper, InfoCardValidator validator, UpdateInfoCardValidator updateValidator)
        {
            this.infoCardService = ınfoCardService;
            _mapper = mapper;
            _validator = validator;
            _updateValidator = updateValidator;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var result = infoCardService.TGetAll();
            var mapper = _mapper.Map<List<ResultInfoCardDto>>(result);
            return View(mapper);
        }

        [HttpGet]
        public IActionResult CreateInfoCard()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateInfoCard(CreateInfoCardDto dto)
        {
            var result = _validator.Validate(dto);
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                return View(dto);
            }
            var mapper = _mapper.Map<InfoCard>(dto);
            infoCardService.TInsert(mapper);
            TempData["Success"] = "Bilgi Kartı Başarıyla Eklendi";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteInfoCard(int InfoCardId)
        {
            var infoCard = infoCardService.TGetById(InfoCardId);
            if (infoCard == null)
            {
                TempData["Error"] = "Bilgi Kartı Bulunamadı";
                return View();
            }
            infoCardService.TDelete(infoCard);
            TempData["Success"] = "Bilgi Kartı başarıyla silindi.";  
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateInfoCard(int id)
        {
            var infoCard = infoCardService.TGetById(id);
            if (infoCard == null)
            {
                return View();
            }
            var mapper=_mapper.Map<UpdateInfoCardDto>(infoCard);
            return View(mapper);
        }
        [HttpPost]
        public IActionResult UpdateInfoCard(UpdateInfoCardDto dto)
        {
            var result = _updateValidator.Validate(dto);
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                return View(dto);
            }
            var mapper = _mapper.Map<InfoCard>(dto);
            infoCardService.TUpdate(mapper);
            TempData["Success"] = "Güncelleme İşlemi Başarıyla Tamamlandı";
            return RedirectToAction("Index");

        }
    }
}
