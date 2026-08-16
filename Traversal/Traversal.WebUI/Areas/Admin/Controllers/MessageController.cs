using AutoMapper;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Abstract;
using Traversal.DtoLayer.DTOS.MessageDtos;

namespace Traversal.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
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
        public IActionResult MessageList()
        {
            var values = messageService.TGetAll();
            var mapper = _mapper.Map<List<ResultMessageDto>>(values);
            return View(mapper);
        }
        [HttpPost]
        public IActionResult DeleteMessage(int id)
        {
            var message = messageService.TGetById(id);
            if (message == null)
                return View();
            messageService.TDelete(message);
            return RedirectToAction("MessageList");
        }
        public IActionResult ReadMessages(int id)
        {
            var values=messageService.TGetListByFilter(x=>x.Status==true);
            var mapper = _mapper.Map<List<ResultMessageDto>>(values);
            return View(mapper);
        }
        [HttpGet]
        public IActionResult UnReadMessages()
        {
            var values = messageService.TGetListByFilter(x=>x.Status==false);
            var mapper = _mapper.Map<List<ResultMessageDto>>(values);
            return View(mapper);
        }
        public IActionResult ChangeStatusTrue(int id)
        {
            var message = messageService.TGetById(id);
            if (message == null)
                return View();

            message.Status = true;
            messageService.TUpdate(message);
            return RedirectToAction("MessageList");

        }
        public IActionResult ChangeStatusFalse(int id)
        {
            var message = messageService.TGetById(id);
            if (message == null)
                return View();

            message.Status = false;
            messageService.TUpdate(message);
            return RedirectToAction("MessageList");
        }
        [HttpGet]
        public IActionResult ExportExcel()
        {
            var message = messageService.TGetAll();
            
            using(var workBook=new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Mesajlar");

                workSheet.Cell(1, 1).Value="Id";
                workSheet.Cell(1, 2).Value = "Ad Soyad";
                workSheet.Cell(1, 3).Value = "Email";
                workSheet.Cell(1, 4).Value = "Gönderim Tarihi";
                workSheet.Cell(1, 5).Value = "Konu";
                workSheet.Cell(1, 6).Value = "İçerik";
                workSheet.Cell(1, 7).Value = "Durum";

                var headerRow = workSheet.Row(1);
                headerRow.Style.Font.Bold = true;
                headerRow.Style.Fill.BackgroundColor = XLColor.FromHtml("#e67e22");
                headerRow.Style.Font.FontColor = XLColor.White;


                var row = 2;

                foreach(var item in message)
                {
                    workSheet.Cell(row, 1).Value = item.MessageId;
                    workSheet.Cell(row, 2).Value = item.NameSurname;
                    workSheet.Cell(row, 3).Value = item.Email;
                    workSheet.Cell(row, 4).Value = item.SendDate.ToString("dd MMM yyyy");
                    workSheet.Cell(row, 5).Value = item.Subject;
                    workSheet.Cell(row, 6).Value = item.Content;
                    workSheet.Cell(row, 7).Value = item.Status;
                    workSheet.Cell(row, 1).Value = item.MessageId;
                    row++;
                }

                workSheet.Columns().AdjustToContents();

                workSheet.SheetView.FreezeRows(1);

                using(var stream=new MemoryStream())
                {
                    workBook.SaveAs(stream);

                    var content=stream.ToArray();

                    return File(
                      content,
                       "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                      $"Mesajlar_{DateTime.Now:yyyyMMdd_HHmm}.xlsx"
                      );
                }


            }
        }
    }
}
