using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Abstract;
using Traversal.DtoLayer.DTOS.NewsletterDtos;

namespace Traversal.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class NewsletterController : Controller
    {
        private readonly INewsletterService newsletterService;
        private readonly IMapper _mapper;
        public NewsletterController(INewsletterService newsletterService, IMapper mapper)
        {
            this.newsletterService = newsletterService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = newsletterService.TGetAll();
            var mapper = _mapper.Map<List<ResultNewsletterDto>>(values);
            return View(mapper);
        }
    }
}
