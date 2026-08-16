using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Abstract;
using Traversal.DtoLayer.DTOS.DestinationDtos;

namespace Traversal.WebUI.Controllers
{
    public class DestinationController : Controller
    {
        private readonly IDestinationService destinationService;
        private readonly IMapper _mapper;

        public DestinationController(IDestinationService destinationService, IMapper mapper)
        {
            this.destinationService = destinationService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var values = destinationService.TGetAll();
            var mapper = _mapper.Map<List<ResultDestinationDto>>(values);
            return View(mapper);
        }
        [HttpGet]
        public IActionResult DestinationDetail(int id)
        {
            var values = destinationService.TGetById(id);
            if (values == null)
            {
                return NotFound(); 
            }

            ViewBag.DestinationId = id;
            var mapper = _mapper.Map<GetDestinationByIdDto>(values);
            return View(mapper);
        }

    }
}
