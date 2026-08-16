using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Abstract;
using Traversal.DtoLayer.DTOS.InfoCardDtos;

namespace Traversal.WebUI.ViewComponents.About
{
    public class InfoCardViewComponent:ViewComponent
    {
        private readonly IInfoCardService ınfoCardService;
        private readonly IMapper _mapper;

        public InfoCardViewComponent(IInfoCardService ınfoCardService, IMapper mapper)
        {
            this.ınfoCardService = ınfoCardService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var result = ınfoCardService.TGetAll();
            var mapper = _mapper.Map<List<ResultInfoCardDto>>(result);
            return View(mapper);
        }
    }
}
