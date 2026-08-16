using AutoMapper;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using Traversal.BusinessLayer.Abstract;
using Traversal.DtoLayer.DTOS.AppUserDtos;
using Traversal.EntityLayer.Entities;

namespace Traversal.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IMapper _mapper;
        public UserController(UserManager<AppUser> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values =  await userManager.Users.ToListAsync();
            var mapper = _mapper.Map<List<ResultAppUserDto>>(values);
            return View(mapper);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                TempData["Error"] = "Kullanıcı Bulunamadı";
                return RedirectToAction("Index");  
            }
            await userManager.DeleteAsync(user);
            TempData["Success"] = "Kullanıcı başarıyla silindi.";   
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UserDetail(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                TempData["Error"] = "Kullanıcı Bulunamadı";
                return RedirectToAction("Index");
            }
            var mapper = _mapper.Map<GetAppUserByIdDto>(user);
            return View(mapper);
        }
        [HttpGet]
        public async Task<IActionResult> ExportExcel()
        {
            var users = userManager.Users.ToList();

            using (var workBook=new XLWorkbook()) //Excel Defteri
            {
                var workSheet = workBook.Worksheets.Add("Kullanıcılar"); // Sayfa Oluşturuyoruz

                workSheet.Cell(1, 1).Value = "ID";
                workSheet.Cell(1, 2).Value = "Ad";
                workSheet.Cell(1, 3).Value = "Soyad";
                workSheet.Cell(1, 4).Value = "Resim";
                workSheet.Cell(1, 5).Value = "Email";
                workSheet.Cell(1, 6).Value = "Kullanıcı Adı";


                var headerRow = workSheet.Row(1);
                headerRow.Style.Font.Bold = true;
                headerRow.Style.Fill.BackgroundColor = XLColor.FromHtml("#e67e22");
                headerRow.Style.Font.FontColor = XLColor.White;

                var row = 2;
                foreach(var item in users)
                {
                    workSheet.Cell(row, 1).Value=item.Id;
                    workSheet.Cell(row, 2).Value = item.Name;
                    workSheet.Cell(row, 3).Value = item.Surname;
                    workSheet.Cell(row, 4).Value = item.ImageUrl;
                    workSheet.Cell(row, 5).Value = item.Email;
                    workSheet.Cell(row, 6).Value = item.UserName;
                    row++;
                }
                workSheet.Columns().AdjustToContents();

                workSheet.SheetView.FreezeRows(1);


                using (var stream=new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                         "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        $"Kullanıcılar_{DateTime.Now:yyyyMMdd_HHmm}.xlsx"
                        );
                }
            }
        }

        [HttpGet]
        public IActionResult ExportPdf()
        {
            var user = userManager.Users.ToList();

            var pdf = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(30);

                    page.Header()
                        .Text("Kullanıcılar")
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
                                    .Padding(5).Text("Ad").Bold().FontColor(Colors.White);

                                header.Cell().Background(Colors.Orange.Medium)
                                    .Padding(5).Text("Soyad").Bold().FontColor(Colors.White);

                                header.Cell().Background(Colors.Orange.Medium)
                                    .Padding(5).Text("Resim").Bold().FontColor(Colors.White);

                                header.Cell().Background(Colors.Orange.Medium)
                                    .Padding(5).Text("Email").Bold().FontColor(Colors.White);

                                header.Cell().Background(Colors.Orange.Medium)
                                    .Padding(5).Text("Kullanıcı Adı").Bold().FontColor(Colors.White);
                            });

                            foreach (var item in user)
                            {
                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                                    .Padding(5).Text(item.Id.ToString());

                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                                    .Padding(5).Text(
                                        $"{item.Name}");

                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                                 .Padding(5).Text(
                                     $"{item.Surname}");

                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                                 .Padding(5).Text(
                                     $"{item.ImageUrl}");

                                 table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                                    .Padding(5).Text(
                                        $"{item.Email}");

                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                                 .Padding(5).Text(
                                     $"{item.UserName}");
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
                $"Kullanıcılar_{DateTime.Now:yyyyMMdd_HHmm}.pdf"
            );
        }
    }
}
