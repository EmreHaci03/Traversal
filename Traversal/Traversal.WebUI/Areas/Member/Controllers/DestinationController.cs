using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Abstract;
using Traversal.DtoLayer.DTOS.DestinationDtos;
using Traversal.EntityLayer.Entities;

namespace Traversal.WebUI.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize]
    public class DestinationController : Controller
    {
        private readonly IDestinationService destinationService;
        private readonly IMapper _mapper;

        public DestinationController(IDestinationService destinationService, IMapper mapper)
        {
            this.destinationService = destinationService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = destinationService.TActiveRoutes();
            var mapper = _mapper.Map<List<ResultDestinationDto>>(values);
            return View(mapper);
        }
        public IActionResult DestinationDetail(int id)
        {
            var values = destinationService.TGetById(id);
            var mapper = _mapper.Map<GetDestinationByIdDto>(values);
            return View(mapper);
        }
    }
}
