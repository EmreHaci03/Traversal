using AutoMapper;
using ClosedXML.Excel;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Traversal.BusinessLayer.Abstract;
using Traversal.BusinessLayer.ValidationRules.DestinationValidators;
using Traversal.DtoLayer.DTOS.DestinationDtos;
using Traversal.EntityLayer.Entities;
using Traversal.WebUI.CQRS.Command;
using Traversal.WebUI.CQRS.Queries;

namespace Traversal.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DestinationController : Controller
    {
        private readonly IMediator mediator;
        private readonly IDestinationService destinationService;
        private readonly IMapper _mapper;
        private readonly DestinationValidator _validator;

        public DestinationController(IDestinationService destinationService, IMapper mapper, IMediator mediator, DestinationValidator validator)
        {
            this.destinationService = destinationService;
            _mapper = mapper;
            this.mediator = mediator;
            _validator = validator;
        }
        [HttpGet]
        public async Task<IActionResult> DestinationList()
        {
            var values = await  mediator.Send(new GetDestinationQuery());
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateDestination()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateDestination(CreateDestinationDto dto)
        {
            var result = _validator.Validate(dto);
            if (!result.IsValid)
            {
                foreach(var item in result.Errors)
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                return View(dto);
            }

            var command = new CreateDestinationCommand
            {
                City = dto.City,
                DayNight = dto.DayNight,
                Price = dto.Price,
                Image = dto.Image,
                Description = dto.Description,
                Capacity = dto.Capacity,
                Status = true,
                CoverImage = dto.CoverImage,
                Details1 = dto.Details1,
                Details2 = dto.Details2,
                Image2 = dto.Image2,
            };

            await mediator.Send(command);
            TempData["Success"] = "Destinasyon başarıyla eklendi.";
            return RedirectToAction("DestinationList"); 
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDestination(int id)
        {
            await mediator.Send(new RemoveDestinationCommand(id));
            return RedirectToAction("DestinationList");
        }

        [HttpGet]
        public IActionResult UpdateDestination(int id)
        {
            var destination = destinationService.TGetById(id);
            var mappedDto = _mapper.Map<UpdateDestinationDto>(destination);  
            return View(mappedDto);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateDestination(UpdateDestinationDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var command = _mapper.Map<UpdateDestinationCommand>(dto);
            await mediator.Send(command);
            TempData["Success"] = "Destinasyon başarıyla Güncellendi.";
            return RedirectToAction("DestinationList");

        }
        [HttpGet]
        public IActionResult ExportExcel()
        {
            var destination = destinationService.TGetAll();

            using(var workBook=new XLWorkbook()) //Excel Defteri
            {
                var worksheet = workBook.Worksheets.Add("Destinasyonlar"); // Sayfa Oluşturuyoruz.

                worksheet.Cell(1, 1).Value = "ID";
                worksheet.Cell(1, 2).Value = "Şehir";
                worksheet.Cell(1, 3).Value = "Gün Sayısı";
                worksheet.Cell(1, 4).Value = "Fiyat";
                worksheet.Cell(1, 5).Value = "Resim";
                worksheet.Cell(1, 6).Value = "Açıklama";

                var headerRow = worksheet.Row(1);
                headerRow.Style.Font.Bold = true;
                headerRow.Style.Fill.BackgroundColor = XLColor.FromHtml("#e67e22");
                headerRow.Style.Font.FontColor = XLColor.White;

                int row = 2;
                foreach(var item in destination)
                {
                    worksheet.Cell(row,1).Value = item.DestinationId;
                    worksheet.Cell(row,2).Value = item.City;
                    worksheet.Cell(row,3).Value = item.DayNight;
                    worksheet.Cell(row,4).Value = item.Price;
                    worksheet.Cell(row,5).Value = item.Image;
                    worksheet.Cell(row,6).Value = item.Description;
                    row++;
                }
                worksheet.Columns().AdjustToContents(); //Sütun genişliklerini otomatik ayarlıyoruz

                //    kullanıcı aşağı kaydırsa bile başlıklar üstte sabit kalır
                worksheet.SheetView.FreezeRows(1);

                using(var stream=new MemoryStream())
                {
                    workBook.SaveAs(stream);

                    // Bellekteki veriyi byte dizisine çeviriyoruz
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",    // Excel dosyasının standart MIME tipi
                        $"Destinasyonlar_{DateTime.Now:yyyyMMdd_HHmm}.xlsx"
                        );

                }

            }
        }

    }
}
