using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Abstract;
using Traversal.DtoLayer.DTOS.DestinationDtos;

namespace Traversal.WebUI.ViewComponents.Default
{
    public class MainSliderViewComponent:ViewComponent
    {
        private readonly IDestinationService destinationService;
        private readonly IMapper _mapper;
        public MainSliderViewComponent(IDestinationService destinationService, IMapper mapper)
        {
            this.destinationService = destinationService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var destinations = destinationService.TGetAll();
            var mapper = _mapper.Map<List<ResultDestinationDto>>(destinations);
            return View(mapper);
        }
    }
}
