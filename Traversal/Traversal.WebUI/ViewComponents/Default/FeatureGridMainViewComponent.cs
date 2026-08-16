using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Abstract;
using Traversal.DtoLayer.DTOS.FeatureMainDtos;

namespace Traversal.WebUI.ViewComponents.Default
{
    public class FeatureGridMainViewComponent:ViewComponent
    {
        private readonly IFeatureMainService featureMainService;
        private readonly IMapper _mapper;

        public FeatureGridMainViewComponent(IFeatureMainService featureMainService, IMapper mapper)
        {
            this.featureMainService = featureMainService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var values = featureMainService.TGetAll().FirstOrDefault();
            var mapper = _mapper.Map<GetFeatureMainDto>(values);
            return View(mapper);
        }
    }
}
