using AutoMapper;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using Traversal.BusinessLayer.Abstract;
using Traversal.BusinessLayer.ValidationRules.GuideValidators;
using Traversal.DtoLayer.DTOS.GuideDtos;
using Traversal.EntityLayer.Entities;

namespace Traversal.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class GuideController : Controller
    {
        private readonly IGuideService guideService;
        private readonly GuideValidator _validator;
        private readonly IMapper _mapper;
        public GuideController(IGuideService guideService, IMapper mapper, GuideValidator validator)
        {
            this.guideService = guideService;
            _mapper = mapper;
            _validator = validator;
        }
        [HttpGet]
        public IActionResult GuideList()
        {
            var result = guideService.TGetAll();
            var mapper = _mapper.Map<List<ResultGuideDto>>(result);
            return View(mapper);
        }

        [HttpGet]
        public IActionResult CreateGuide()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateGuide(CreateGuideDto dto)
        {
            var result = _validator.Validate(dto);
            if (!result.IsValid)
            {
                foreach (var item in result.Errors){ 
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            return View(dto);
            }

            var mapper = _mapper.Map<Guide>(dto);
            guideService.TInsert(mapper);
            TempData["Success"] = "Rehber Başarıyla Eklendi";
            return RedirectToAction("GuideList");
        }

        [HttpPost]
        public IActionResult DeleteGuide(int id)
        {
            var guide = guideService.TGetById(id);
            if (guide == null)
                return View();

            guideService.TDelete(guide);
            TempData["Success"] = "Rehber Başarıyla Silindi";
            return RedirectToAction("GuideList");
        }
        [HttpGet]
        public IActionResult UpdateGuide(int id)
        {
            var guide = guideService.TGetById(id);
            if (guide == null)
                return View();

            var mapper=_mapper.Map<UpdateGuideDto>(guide);
            return View(mapper);
        }
        [HttpPost]  
        public IActionResult UpdateGuide(UpdateGuideDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var mapper = _mapper.Map<Guide>(dto);
            guideService.TUpdate(mapper);
            TempData["Success"] = "Rehber Başarıyla Güncellendi";
            return RedirectToAction("GuideList");
        }

        [HttpGet]
        public IActionResult ExportExcel()
        {
            var guide = guideService.TGetAll();

            using(var workBook=new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Rehberlerimiz");

                workSheet.Cell(1, 1).Value = "Id";
                workSheet.Cell(1, 2).Value = "Ad Soyad";
                workSheet.Cell(1, 3).Value = "Açıklama";
                workSheet.Cell(1, 4).Value = "Resim";
                workSheet.Cell(1, 5).Value = "Twitter";
                workSheet.Cell(1, 6).Value = "İnstagram";
                workSheet.Cell(1, 7).Value = "Durum";


                var headerRow = workSheet.Row(1);
                headerRow.Style.Font.Bold = true;
                headerRow.Style.Fill.BackgroundColor = XLColor.FromHtml("#e67e22");
                headerRow.Style.Font.FontColor = XLColor.White;


                var row = 2;
                foreach(var item in guide)
                {
                    workSheet.Cell(row, 1).Value = item.GuideId;
                    workSheet.Cell(row, 2).Value = item.Name;
                    workSheet.Cell(row, 3).Value = item.Description;
                    workSheet.Cell(row, 4).Value = item.Image;
                    workSheet.Cell(row, 5).Value = item.TwitterUrl;
                    workSheet.Cell(row, 6).Value = item.InstagramUrl;
                    workSheet.Cell(row, 7).Value = item.Status;
                    row++;
                }

                workSheet.Columns().AdjustToContents();

                workSheet.SheetView.FreezeRows(1);

                using(var stream=new MemoryStream())
                {
                    workBook.SaveAs(stream);

                    var content = stream.ToArray();
                    return File(
                      content,
                      "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",    // Excel dosyasının standart MIME tipi
                      $"Rehberlerimiz_{DateTime.Now:yyyyMMdd_HHmm}.xlsx");
                }

            }
        }

        [HttpGet]
        public IActionResult ExportPdf()
        {
            var guide = guideService.TGetAll();

            var pdf = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(30);

                    page.Header()
                        .Text("Rehberlerimiz")
                        .FontSize(20)
                        .Bold()
                        .FontColor(Colors.Orange.Medium);

                    page.Content()
                        .PaddingTop(20)
                        .Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            // Başlıklar
                            table.Header(header =>
                            {
                                header.Cell().Background(Colors.Orange.Medium)
                                    .Padding(5).Text("Id").Bold().FontColor(Colors.White);

                                header.Cell().Background(Colors.Orange.Medium)
                                    .Padding(5).Text("Ad Soyad").Bold().FontColor(Colors.White);

                                header.Cell().Background(Colors.Orange.Medium)
                                    .Padding(5).Text("Açıklama").Bold().FontColor(Colors.White);

                                header.Cell().Background(Colors.Orange.Medium)
                                    .Padding(5).Text("Resim").Bold().FontColor(Colors.White);

                                header.Cell().Background(Colors.Orange.Medium)
                                    .Padding(5).Text("Twitter").Bold().FontColor(Colors.White);

                                header.Cell().Background(Colors.Orange.Medium)
                                    .Padding(5).Text("Instagram").Bold().FontColor(Colors.White);

                                header.Cell().Background(Colors.Orange.Medium)
                                    .Padding(5).Text("Durum").Bold().FontColor(Colors.White);
                            });

                            foreach (var item in guide)
                            {
                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                                    .Padding(5).Text(item.GuideId.ToString());

                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                                    .Padding(5).Text(
                                        $"{item.Name}");

                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                                 .Padding(5).Text(
                                     $"{item.Description}");

                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                                 .Padding(5).Text(
                                     $"{item.Image}");

                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                                   .Padding(5).Text(
                                       $"{item.TwitterUrl}");

                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                                 .Padding(5).Text(
                                     $"{item.InstagramUrl}");
                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                                .Padding(5).Text(
                                    $"{item.Status}");
                            }
                        });

                    page.Footer()
                        .AlignCenter()
                        .Text(text =>
                        {
                            text.Span("Oluşturulma: ");
                            text.Span(DateTime.Now.ToString("dd.MM.yyyy HH:mm"));
                        });
                });
            }).GeneratePdf();

            return File(
                pdf,
                "application/pdf",
                $"Rehberlerimiz_{DateTime.Now:yyyyMMdd_HHmm}.pdf"
            );
        }
    }
}
