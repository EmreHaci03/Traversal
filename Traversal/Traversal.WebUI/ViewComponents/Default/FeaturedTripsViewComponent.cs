using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Abstract;
using Traversal.DtoLayer.DTOS.FeatureGridDtos;

namespace Traversal.WebUI.ViewComponents.Default
{
    public class FeaturedTripsViewComponent:ViewComponent
    {
        private readonly IFeatureGridService featureGridService;
        private readonly IMapper _mapper;

        public FeaturedTripsViewComponent(IFeatureGridService featureGridService, IMapper mapper)
        {
            this.featureGridService = featureGridService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var values = featureGridService.TGetAll();
            var mapper = _mapper.Map<List<ResultFeatureGridDto>>(values);
            return View(mapper);
        }
    }
}
