using System.Text.Json;
using HouseMarket.Models.HouseMarketOffer;
using HouseMarket.OfferService.DataModel;
using HouseMarket.OfferService.DataModel.InputData.GeneratedClasses;
using Microsoft.AspNetCore.Mvc;
using HouseMarket.OfferService.Services.Interfaces;

namespace HouseMarket.Controllers
{
    public class HouseMarketOfferController : Controller
    {
        private readonly ITopBrokerService _topBrokerService;
        private readonly IHouseMarketOfferService _houseMarketOfferService;
        public HouseMarketOfferController(ITopBrokerService topBrokerService, IHouseMarketOfferService houseMarketOfferService)
        {
            _topBrokerService = topBrokerService;
            _houseMarketOfferService = houseMarketOfferService;
        }
        public IActionResult Index()
        {
            var httpClient = new HttpClient();
            var model = new BrokersModel();
            List<Broker> top10Brokers;

            try
            {
                var houseMarketOffer = _houseMarketOfferService.GetHouseOffer(httpClient, false);
                top10Brokers = _topBrokerService.GetTopBrokers(houseMarketOffer, 10);
            }
            catch (Exception)
            {
                var sampleDataString = System.IO.File.ReadAllText("..\\HouseMarket.OfferService\\bin\\Debug\\net6.0\\DataModel\\InputData\\Json\\Houses.json");
                var sampleDataHouseMarket = JsonSerializer.Deserialize<HouseMarketOffer>(sampleDataString);
                top10Brokers = _topBrokerService.GetTopBrokers(sampleDataHouseMarket, 10);
            }
          
            model.Top10Brokers = top10Brokers;
          

            return View(model);
        }
    }
}
