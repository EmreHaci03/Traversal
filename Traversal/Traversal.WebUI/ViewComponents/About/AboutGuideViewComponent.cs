using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Abstract;
using Traversal.DtoLayer.DTOS.GuideDtos;

namespace Traversal.WebUI.ViewComponents.About
{
    public class AboutGuideViewComponent:ViewComponent
    {
        private readonly IGuideService guideService;
        private readonly IMapper _mapper;

        public AboutGuideViewComponent(IGuideService guideService, IMapper mapper)
        {
            this.guideService = guideService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var values = guideService.TGetAll();
            var mapper = _mapper.Map<List<ResultGuideDto>>(values);
            return View(mapper);
        }
    }
}
