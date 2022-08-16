using HouseMarket.Models.HouseMarketOffer;
using HouseMarket.OfferService.DataModel;
using HouseMarket.OfferService.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HouseMarket.Controllers
{
    public class HouseMarketOfferController : Controller
    {
        public IActionResult Index()
        {
            var httpClient = new HttpClient();
            var model = new BrokersModel();
            var offerService = new HouseMarketOfferService(httpClient);
            var enableTestData = true;
            var testData = System.IO.File.ReadAllText("C:\\Users\\Gebruiker\\source\\repos\\HouseMarket\\HouseMarket.OfferService\\DataModel\\TestData\\Houses.json");

            model.HouseMarketOffer = enableTestData ? JsonSerializer.Deserialize<HouseMarketOffer>(testData) : offerService.GetOfferAsync().Result;
            model.TopBrokers = model.HouseMarketOffer?.Objects.GroupBy(x => x.MakelaarId).OrderByDescending(x => x.Count()).Take(10);


            return View(model);
        }
    }
}
