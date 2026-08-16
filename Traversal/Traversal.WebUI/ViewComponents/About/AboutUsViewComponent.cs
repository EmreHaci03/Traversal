using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Abstract;
using Traversal.DtoLayer.DTOS.AboutDtos;

namespace Traversal.WebUI.ViewComponents.About
{
    public class AboutUsViewComponent:ViewComponent
    {
        private readonly IAboutService aboutService;
        private readonly IMapper _mapper;

        public AboutUsViewComponent(IAboutService aboutService, IMapper mapper)
        {
            this.aboutService = aboutService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var values = aboutService.TGetAll().FirstOrDefault();
            var mapper = _mapper.Map<GetAboutDto>(values);
            return View(mapper);
        }
    }
}
