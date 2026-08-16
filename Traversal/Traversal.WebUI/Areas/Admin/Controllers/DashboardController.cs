using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Traversal.BusinessLayer.Abstract;
using Traversal.DataAccessLayer.Concrete;

namespace Traversal.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly TraversalContext traversalContext;
        private readonly IContactService contactService;
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration configuration;

        public DashboardController(TraversalContext traversalContext, IContactService contactService, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            this.traversalContext = traversalContext;
            this.contactService = contactService;
            this.httpClientFactory = httpClientFactory;
            this.configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.DestinationCount = traversalContext.Destinations.Count();
            ViewBag.ReservationCount = traversalContext.Reservations.Count();
            ViewBag.UserCount = traversalContext.Users.Count();
            ViewBag.UnreadMessageCount = traversalContext.Messages.Count(x => x.Status == false);
            ViewBag.RecentMessages = traversalContext.Messages.OrderByDescending(x => x.MessageId).Take(5).ToList();
            ViewBag.PendingComments = traversalContext.Comments.Where(x => x.CommentStatus == false).ToList();
            ViewBag.TopDestinations = traversalContext.Destinations.Take(5).ToList();
            ViewBag.ContactId = contactService.TGetAll().Select(x => x.ContactId).FirstOrDefault();

            var currencyClient = httpClientFactory.CreateClient("CurrencyApi");

            var UsdtryResponse = await currencyClient.GetAsync("https://currency-conversion-and-exchange-rates.p.rapidapi.com/latest?base=USD&symbols=TRY");
            var EurtryResponse = await currencyClient.GetAsync("https://currency-conversion-and-exchange-rates.p.rapidapi.com/latest?base=EUR&symbols=TRY");
            var GbptryResponse = await currencyClient.GetAsync("https://currency-conversion-and-exchange-rates.p.rapidapi.com/latest?base=GBP&symbols=TRY");

            dynamic usdTryData = JsonConvert.DeserializeObject(await UsdtryResponse.Content.ReadAsStringAsync());
            dynamic EurTryData = JsonConvert.DeserializeObject(await EurtryResponse.Content.ReadAsStringAsync());
            dynamic GbpTryData = JsonConvert.DeserializeObject(await GbptryResponse.Content.ReadAsStringAsync());

            decimal UsdtoTry = usdTryData.rates.TRY;
            decimal EurtoTry = EurTryData.rates.TRY;
            decimal GbptoTry = GbpTryData.rates.TRY;

            ViewBag.UsdTry = UsdtoTry;   
            ViewBag.EurTry = EurtoTry;   
            ViewBag.GbpTry = GbptoTry;   

            var goldClient = httpClientFactory.CreateClient("GoldApi");
            var goldResponse = await goldClient.GetAsync("https://harem-altin-anlik-altin-fiyatlari-live-rates-gold.p.rapidapi.com/economy/live-exchange-rates?type=gold&code=GRAMALTIN");

            dynamic GoldData = JsonConvert.DeserializeObject(await goldResponse.Content.ReadAsStringAsync());
            decimal GoldPrice = GoldData.data[0].sell;

            ViewBag.GoldTry = GoldPrice;

            var weatherclient = httpClientFactory.CreateClient("WeatherApi");
            var weatherResponse = await weatherclient.GetAsync("https://open-weather13.p.rapidapi.com/city?city=%C4%B0stanbul&lang=TR");

            dynamic WeatherData=JsonConvert.DeserializeObject(await weatherResponse.Content.ReadAsStringAsync());

            decimal tempFahrenheit = WeatherData.main.temp;
            decimal TempCelcius = (tempFahrenheit - 32) * 5 / 9;


            ViewBag.WeatherCity = (string)WeatherData.name;            
            ViewBag.WeatherTemp = Math.Round(TempCelcius);                 
            ViewBag.WeatherDesc = (string)WeatherData.weather[0].description;

            return View();
        }
    }
}