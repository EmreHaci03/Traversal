using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Abstract;
using Traversal.DtoLayer.DTOS.TestimonialDtos;

namespace Traversal.WebUI.ViewComponents.Default
{
    public class TestimonialViewComponent:ViewComponent
    {
        private readonly ITestimonialService testimonialService;
        private readonly IMapper _mapper;

        public TestimonialViewComponent(ITestimonialService testimonialService, IMapper mapper)
        {
            this.testimonialService = testimonialService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var values = testimonialService.TGetListByFilter(x=>x.Status==true);
            var mapper = _mapper.Map<List<ResultTestimonialDto>>(values);
            return View(mapper);
        }
    }
}
