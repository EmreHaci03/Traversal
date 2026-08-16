using AutoMapper;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Threading.Tasks;
using Traversal.BusinessLayer.Abstract;
using Traversal.DtoLayer.DTOS.ReservationDtos;
using Traversal.EntityLayer.Entities;

namespace Traversal.WebUI.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize]
    public class ReservationController : Controller
    {
        private readonly IReservationService reservationService;
        private readonly IDestinationService destinationService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> userManager;
        private readonly IConfiguration configuration;

        public ReservationController(IReservationService reservationService, IMapper mapper, UserManager<AppUser> userManager, IDestinationService destinationService, IConfiguration configuration)
        {
            this.reservationService = reservationService;
            this._mapper = mapper;
            this.userManager = userManager;
            this.destinationService = destinationService;
            this.configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> MyCurrentReservation()
        {
            var user=await userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");

            var values = reservationService.TGetListByFilterWithDestination(x => x.AppUserId == user.Id && x.Status == "Beklemede" && x.ReservationDate >= DateTime.Now);
            if (values == null)
                return RedirectToAction("Index", "Destination", new { area = "Member" });

            var mapper = _mapper.Map<List<ResultReservationDto>>(values);

            return View(mapper);
        }
        [HttpGet]
        public async Task<IActionResult> MyOldReservation()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");

            var values = reservationService.TGetListByFilterWithDestination(x => x.AppUserId == user.Id && x.ReservationDate < DateTime.Now);
            if (values == null)
                return RedirectToAction("Index", "Destination", new { area = "Member" });

            var mapper = _mapper.Map<List<ResultReservationDto>>(values);
            return View(mapper);

        }
        [HttpGet]
        public async Task<IActionResult> MyCancelledReservation()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");
            var values = reservationService.TGetListByFilterWithDestination(x => x.AppUserId == user.Id && x.Status == "İptal");

            if(values==null)
                return RedirectToAction("Index", "Destination", new { area = "Member" });

            var mapper = _mapper.Map<List<ResultReservationDto>>(values);
            return View(mapper);
        }
        [HttpGet]
        public IActionResult CreateReservation(int id)
        {
            var destination = destinationService.TGetById(id); 
            if (destination == null)
            {
                return RedirectToAction("Index", "Destination", new { area = "" });
            }
            var model = new CreateReservationDto
            {
                DestinationId = id,
                DestinationCity = destination.City,
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var user = await userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");

            dto.AppUserId = user.Id;
            dto.Status = "Beklemede";

            var mapper = _mapper.Map<Reservation>(dto);
            reservationService.TInsert(mapper);

            var destination = destinationService.TGetById(dto.DestinationId);
            var reservationCode = "VIT-" + Guid.NewGuid().ToString().Substring(0, 8).ToUpper();

            await SendReservationMail(
                user.Email,
                user.Name + " " + user.Surname,
                dto.DestinationCity,
                reservationCode,
                int.Parse(dto.PersonCount),
                destination.Price * int.Parse(dto.PersonCount)
            );

            TempData["Success"] = "Rezervasyonunuz oluşturuldu, onay maili gönderildi.";
            return RedirectToAction("MyCurrentReservation");
        }

        private async Task SendReservationMail(string toEmail, string nameSurname, string tourTitle, string reservationCode, int personCount, decimal totalPrice)
        {
            var mimeMessage = new MimeMessage();

            var mailboxAddressFrom = new MailboxAddress(
                configuration["MailSettings:SenderName"],
                configuration["MailSettings:SenderEmail"]);
            mimeMessage.From.Add(mailboxAddressFrom);

            var mailboxAddressTo = new MailboxAddress(nameSurname, toEmail);
            mimeMessage.To.Add(mailboxAddressTo);

            mimeMessage.Subject = "🎉 Rezervasyon Onayı - Traversal";

            mimeMessage.Body = new TextPart("html")
            {
                Text = $@"
                <div style='font-family:Arial;padding:20px;background:#f4f4f4'>
                    <div style='max-width:600px;margin:auto;background:#fff;padding:20px;border-radius:10px'>
                        <h2>🎉 Rezervasyon Başarılı</h2>
                        <p>Merhaba <b>{nameSurname}</b>,</p>
                        <p>Rezervasyonunuz oluşturuldu.</p>
                        <hr>
                        <h3>📌 Bilgiler</h3>
                        <ul>
                            <li><b>Tur:</b> {tourTitle}</li>
                            <li><b>Kod:</b> {reservationCode}</li>
                            <li><b>Kişi:</b> {personCount}</li>
                            <li><b>Tutar:</b> {totalPrice} ₺</li>
                        </ul>
                        <p style='color:gray;font-size:12px'>Bu mail otomatik gönderildi.</p>
                    </div>
                </div>"
            };

            using var smtpClient = new SmtpClient();

            int port = configuration.GetValue<int>("MailSettings:Port");

            await smtpClient.ConnectAsync(
                configuration["MailSettings:SmtpServer"],
                port,
                SecureSocketOptions.StartTls);

            await smtpClient.AuthenticateAsync(
                configuration["MailSettings:SenderEmail"],
                configuration["MailSettings:SenderPassword"]);

            await smtpClient.SendAsync(mimeMessage);
            await smtpClient.DisconnectAsync(true);
        }
    }
}
