using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Abstract;
using Traversal.BusinessLayer.ValidationRules.TestimonialValidators;
using Traversal.DtoLayer.DTOS.TestimonialDtos;
using Traversal.EntityLayer.Entities;

namespace Traversal.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService testimonialService;
        private readonly TestimonialValidator _validator;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper, TestimonialValidator validator)
        {
            this.testimonialService = testimonialService;
            _mapper = mapper;
            _validator = validator;
        }
        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = testimonialService.TGetAll();
            var mapper = _mapper.Map<List<ResultTestimonialDto>>(values);
            return View(mapper);
        }
        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto dto)
        {
            var result = _validator.Validate(dto);
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                return View(dto);
            }

            var mapper = _mapper.Map<Testimonial>(dto);
            testimonialService.TInsert(mapper);
            return RedirectToAction("TestimonialList");
        }

        [HttpPost]
        public IActionResult DeleteTestimonial(int id)
        {
            var testimonial = testimonialService.TGetById(id);
            if (testimonial == null)
            {
                TempData["Error"] = "Silinmek İstenen Referans Bulunamadı";
                return RedirectToAction("TestimonialList");
            }

            testimonialService.TDelete(testimonial);
            return RedirectToAction("TestimonialList");
        }

        [HttpGet]
        public IActionResult UpdateTestimonial(int id)
        {
            var testimonial = testimonialService.TGetById(id);
            if (testimonial == null)
                TempData["UpdateError"] = "Güncellenmek İstenen Referans Bulunamadı";

            var mapper = _mapper.Map<UpdateTestimonialDto>(testimonial);
            return View(mapper);
        }
        [HttpPost]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var mapper = _mapper.Map<Testimonial>(dto);
            testimonialService.TUpdate(mapper);
            TempData["Update"] = "Güncelleme İşlemi Başarıyla Tamamlandı";
            return RedirectToAction("TestimonialList");
        }
    }
}
