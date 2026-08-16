using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Traversal.BusinessLayer.Abstract;
using Traversal.DataAccessLayer.Concrete;
using Traversal.DtoLayer.DTOS.DestinationDtos;

namespace Traversal.WebUI.ViewComponents.Default
{
    public class PopularDestinationsViewComponent:ViewComponent
    {
        private readonly IDestinationService destinationService;
        private readonly IMapper mapper;

        public PopularDestinationsViewComponent(TraversalContext traversalContext, IMapper mapper, IDestinationService destinationService)
        {
            this.mapper = mapper;
            this.destinationService = destinationService;
        }

        public IViewComponentResult Invoke()
        {
            var values = destinationService.TActiveRoutes();
            var mappedValues = mapper.Map<List<ResultDestinationDto>>(values);
            return View(mappedValues);
        }
    }
}
