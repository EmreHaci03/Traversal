using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Abstract;
using Traversal.DtoLayer.DTOS.MessageDtos;
using Traversal.EntityLayer.Entities;

namespace Traversal.WebUI.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessageService messageService;
        private readonly IMapper _mapper;

        public MessageController(IMessageService messageService, IMapper mapper)
        {
            this.messageService = messageService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto dto)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Lütfen tüm alanları doldurun.";
                return RedirectToAction("Index", "Contact");
            }

            var message = _mapper.Map<Message>(dto);
            message.SendDate = DateTime.Now;
            message.Status = false;
            messageService.TInsert(message);

            TempData["Success"] = "Mesajınız Başarıyla Gönderildi";
            return RedirectToAction("Index", "Contact");
        }
    }
}