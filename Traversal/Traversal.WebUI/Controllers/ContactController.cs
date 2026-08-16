using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Abstract;
using Traversal.DtoLayer.DTOS.ContactDtos;

namespace Traversal.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            this.contactService = contactService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = contactService.TGetAll().FirstOrDefault(x=>x.Status==true);
            var mapper = _mapper.Map<GetContactDto>(values);
            return View(mapper);
        }
    }
}
