using AutoMapper;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using Traversal.BusinessLayer.Abstract;
using Traversal.DtoLayer.DTOS.ReservationDtos;

namespace Traversal.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ReservationController : Controller
    {
        private readonly IReservationService reservationService;
        private readonly IMapper _mapper;
        public ReservationController(IReservationService reservationService, IMapper mapper)
        {
            this.reservationService = reservationService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ReservationList()
        {
            var values = reservationService.TGetListByFilterWithDestination(x=>true);
            var mapper = _mapper.Map<List<ResultReservationDto>>(values);
            return View(mapper);
        }
        [HttpPost]
        public IActionResult ApproveReservation(int id)
        {
            var reservation= reservationService.TGetById(id);
            if (reservation == null)
                return View();
            reservation.Status = "Onaylandı";
            reservationService.TUpdate(reservation);
            return RedirectToAction("ReservationList");
        }

        [HttpPost]
        public IActionResult CancelReservation(int id)
        {
            var reservation = reservationService.TGetById(id);
            if (reservation == null)
                return View();
            reservation.Status = "İptal";
            reservationService.TUpdate(reservation);
            return RedirectToAction("ReservationList");
        }

        [HttpGet]
        public IActionResult ExportExcel()
        {
            var reservation = reservationService.TReservationListWithUser();

            using(var workBook=new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Rezervasyonlar");

                workSheet.Cell(1, 1).Value = "Rezervasyon Id";
                workSheet.Cell(1, 2).Value = "Kullanıcı Adı";
                workSheet.Cell(1, 3).Value = "Destinasyon Şehri";
                workSheet.Cell(1, 4).Value = "Kişi Sayısı";
                workSheet.Cell(1, 5).Value = "Rezervasyon Tarihi";
                workSheet.Cell(1, 6).Value = "Durum";

                var headerRow = workSheet.Row(1);
                headerRow.Style.Font.Bold = true;
                headerRow.Style.Fill.BackgroundColor = XLColor.FromHtml("#e67e22");
                headerRow.Style.Font.FontColor = XLColor.White;


                var row = 2;
                foreach(var item in reservation)
                {
                    workSheet.Cell(row, 1).Value = item.ReservationId;
                    workSheet.Cell(row, 2).Value = item.AppUser.Name + " " + item.AppUser.Surname;
                    workSheet.Cell(row, 3).Value = item.Destination.City;
                    workSheet.Cell(row, 4).Value = item.PersonCount;
                    workSheet.Cell(row, 5).Value = item.ReservationDate;
                    workSheet.Cell(row, 6).Value = item.Status;
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
                        $"Rezervasyonlar_{DateTime.Now:yyyyMMdd_HHmm}.xlsx");
                }
            }
        }

        [HttpGet]
        public IActionResult ExportPdf()
        {
            var reservations = reservationService.TReservationListWithUser();

            var pdf = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(30);

                    page.Header()
                        .Text("Rezervasyonlar")
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
                                    .Padding(5).Text("Rezervasyon Id").Bold().FontColor(Colors.White);

                                header.Cell().Background(Colors.Orange.Medium)
                                    .Padding(5).Text("Kullanıcı").Bold().FontColor(Colors.White);

                                header.Cell().Background(Colors.Orange.Medium)
                                    .Padding(5).Text("Destinasyon").Bold().FontColor(Colors.White);

                                header.Cell().Background(Colors.Orange.Medium)
                                    .Padding(5).Text("Kişi").Bold().FontColor(Colors.White);

                                header.Cell().Background(Colors.Orange.Medium)
                                    .Padding(5).Text("Tarih").Bold().FontColor(Colors.White);

                                header.Cell().Background(Colors.Orange.Medium)
                                    .Padding(5).Text("Durum").Bold().FontColor(Colors.White);
                            });

                            foreach (var item in reservations)
                            {
                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                                    .Padding(5).Text(item.ReservationId.ToString());

                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                                    .Padding(5).Text(
                                        $"{item.AppUser.Name} {item.AppUser.Surname}");

                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                                    .Padding(5).Text(item.Destination.City);

                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                                    .Padding(5).Text(item.PersonCount.ToString());

                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                                    .Padding(5).Text(
                                        item.ReservationDate.ToString("dd.MM.yyyy"));

                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                                    .Padding(5).Text(item.Status);
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
                $"Rezervasyonlar_{DateTime.Now:yyyyMMdd_HHmm}.pdf"
            );
        }
    }
}
