using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Abstract;
using Traversal.DtoLayer.DTOS.SubAboutDtos;

namespace Traversal.WebUI.ViewComponents.Default
{
    public class AboutTeaserViewComponent:ViewComponent
    {
        private readonly ISubAboutService subAboutService;
        private readonly IMapper _mapper;

        public AboutTeaserViewComponent(IMapper mapper, ISubAboutService subAboutService)
        {
            _mapper = mapper;
            this.subAboutService = subAboutService;
        }

        public IViewComponentResult Invoke()
        {
            var values = subAboutService.TGetAll();
            var mapper = _mapper.Map<List<ResultSubAboutDto>>(values);
            return View(mapper);
        }
    }
}
