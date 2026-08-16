using AutoMapper;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using Traversal.BusinessLayer.Abstract;
using Traversal.DtoLayer.DTOS.CommentDtos;

namespace Traversal.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;
        private readonly IMapper _mapper;
        public CommentController(ICommentService commentService, IMapper mapper)
        {
            this.commentService = commentService;
            _mapper = mapper;
        }

        public IActionResult CommentList()
        {
            var values = commentService.TGetAll();
            var mapper = _mapper.Map<List<ResultCommentDto>>(values);
            return View(mapper);
        }
        [HttpGet]
        public IActionResult ExportExcel()
        {
            var comment = commentService.TCommentListWihDestination();

            using(var workBook=new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Yorumlar");

                workSheet.Cell(1, 1).Value="Id";
                workSheet.Cell(1, 2).Value = "Ad Soyad";
                workSheet.Cell(1, 3).Value = "Yorum Tarihi";
                workSheet.Cell(1, 4).Value = "İçerik";
                workSheet.Cell(1, 5).Value = "Yorum Yapılan Şehir";

                var headerRow = workSheet.Row(1);
                headerRow.Style.Font.Bold = true;
                headerRow.Style.Fill.BackgroundColor = XLColor.FromHtml("#e67e22");
                headerRow.Style.Font.FontColor = XLColor.White;

                var row = 2;
                foreach(var item in comment)
                {
                    workSheet.Cell(row, 1).Value = item.CommentId;
                    workSheet.Cell(row, 2).Value = item.NameSurname;
                    workSheet.Cell(row, 3).Value = item.CommentDate.ToString("dd MMM yyyy");
                    workSheet.Cell(row, 4).Value = item.Content;
                    workSheet.Cell(row, 5).Value = item.Destination.City;
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
                     $"Yorumlar_{DateTime.Now:yyyyMMdd_HHmm}.xlsx");

                }
            }
        }

        [HttpGet]
        public IActionResult ExportPdf()
        {
            var comment = commentService.TCommentListWihDestination();

            var pdf = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(30);

                    page.Header()
                        .Text("Yorumlar")
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
                                    .Padding(5).Text("Tarih").Bold().FontColor(Colors.White);

                                header.Cell().Background(Colors.Orange.Medium)
                                    .Padding(5).Text("İçerik").Bold().FontColor(Colors.White);

                                header.Cell().Background(Colors.Orange.Medium)
                                    .Padding(5).Text("Durum").Bold().FontColor(Colors.White);

                                header.Cell().Background(Colors.Orange.Medium)
                                    .Padding(5).Text("Yorum Yapılan Destinasyon").Bold().FontColor(Colors.White);
                            });

                            foreach (var item in comment)
                            {
                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                                    .Padding(5).Text(item.CommentId.ToString());

                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                                    .Padding(5).Text(
                                        $"{item.NameSurname}");

                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                                 .Padding(5).Text(
                                     $"{item.CommentDate}");

                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                                 .Padding(5).Text(
                                     $"{item.Content}");

                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                                   .Padding(5).Text(
                                       $"{item.CommentStatus}");

                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                                 .Padding(5).Text(
                                     $"{item.Destination.City}");
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
                $"Yorumlar_{DateTime.Now:yyyyMMdd_HHmm}.pdf"
            );
        }
    }
}
