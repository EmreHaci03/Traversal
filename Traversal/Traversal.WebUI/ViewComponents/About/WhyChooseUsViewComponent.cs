using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Abstract;
using Traversal.DtoLayer.DTOS.WhyChooseDtos;

namespace Traversal.WebUI.ViewComponents.About
{
    public class WhyChooseUsViewComponent:ViewComponent
    {
        private readonly IWhyChooseUsService whyChooseUsService;
        private readonly IMapper _mapper;
        public WhyChooseUsViewComponent(IWhyChooseUsService whyChooseUsService, IMapper mapper)
        {
            this.whyChooseUsService = whyChooseUsService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var values = whyChooseUsService.TGetAll().FirstOrDefault();
            var mapper = _mapper.Map<GetWhyChooseUsDto>(values);
            return View(mapper);
        }
    }
}
