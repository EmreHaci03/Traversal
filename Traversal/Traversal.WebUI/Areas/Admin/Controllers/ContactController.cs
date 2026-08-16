using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Abstract;
using Traversal.DtoLayer.DTOS.ContactDtos;
using Traversal.EntityLayer.Entities;

namespace Traversal.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
        private readonly IContactService contactService;
        private readonly IMapper _mapper;
        public ContactController(IContactService contactService, IMapper mapper)
        {
            this.contactService = contactService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ContactList()
        {
            var values = contactService.TGetAll().FirstOrDefault();
            var mapper = _mapper.Map<GetContactDto>(values);
            return View(mapper);
        }

        [HttpPost]  
        public IActionResult ChangeContactStatusTrue(int id)
        {
            var contact = contactService.TGetById(id);
            if (contact == null)
                return View();
            contact.Status = true;
            contactService.TUpdate(contact);
            TempData["Success"] = "Kayıt Aktif hale getirildi.";
            return RedirectToAction("ContactList");
        }
        [HttpPost]
        public IActionResult ChangeContactStatusFalse(int id)
        {
            var contact = contactService.TGetById(id);
            if (contact == null)
                return View();
            contact.Status = false;
            contactService.TUpdate(contact);
            TempData["Success"] = "Kayıt pasif hale getirildi.";
            return RedirectToAction("ContactList");
        }
        [HttpGet]
        public IActionResult UpdateContact(int id)
        {
            var contact=contactService.TGetById(id);
            if (contact == null)
                return View();
            var mapper = _mapper.Map<UpdateContactDto>(contact);
            return View(mapper);
        }
        [HttpPost]
        public IActionResult UpdateContact(UpdateContactDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var mapper = _mapper.Map<Contact>(dto);
            contactService.TUpdate(mapper);
            return RedirectToAction("ContactList");
        }
    }
}
