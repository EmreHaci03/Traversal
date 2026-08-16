using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Abstract;
using Traversal.DtoLayer.DTOS.NewsletterDtos;
using Traversal.EntityLayer.Entities;

namespace Traversal.WebUI.Controllers
{
    public class NewsletterController : Controller
    {
        private readonly INewsletterService newsletterService;
        private readonly IMapper _mapper;
        public NewsletterController(INewsletterService newsletterService, IMapper mapper)
        {
            this.newsletterService = newsletterService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult CreateNewsletter()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateNewsletter(CreateNewsletterDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);
            var values = _mapper.Map<Newsletter>(dto);
            newsletterService.TInsert(values);
            TempData["Newsletter"] = "Bültene Başarıyla Eklendiniz";
            return RedirectToAction("Index", "Default");
        }
    }
}
